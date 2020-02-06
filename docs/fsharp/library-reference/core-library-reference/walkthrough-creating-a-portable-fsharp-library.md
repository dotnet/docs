---
title: Walkthrough - Creating a Portable F# Library
description: Walkthrough - Creating a Portable F# Library
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 481f0e18-f6d5-4720-809c-c4fef8ad5637 
---

# Walkthrough: Creating a Portable F# Library

By following this walkthrough, you can create an assembly in F# that you can use with a Silverlight app, a traditional desktop app, or in a Windows Store app that you create by using .NET APIs. In this way, you can write the UI portion of your app in another .NET language, such as C# or Visual Basic, and the algorithmic portion in F#. You can also support different user interfaces that target different platforms.

You can't use the Windows Store UI directly from F#, so we recommend that you write the UI for your Windows Store app in another .NET language and write the F# code in a portable library. You can write Silverlight and Windows Presentation Foundation (WPF) UI in F# directly, but you might want to take advantage of the additional design tools that are available when you write C# or Visual Basic code in Visual Studio.


## Prerequisites
To create a Windows Store app, you must have Windows 8.1 on your development computer.

To create a Silverlight project, you must have Silverlight 5 on your development computer.


## The Spreadsheet App
In this walkthrough, you'll develop a simple spreadsheet that presents a grid to the user and accepts numerical input and formulas in its cells. The F# layer processes and validates all input and, in particular, parses the formula text and computes the results of formulas. First, you'll create the F# algorithmic code, which includes code for parsing expressions that involve cell references, numbers, and mathematical operators. This app also includes the code to track which cells must be updated when a user updates the contents of another cell. Next, you'll create the user interfaces.

The following figure shows the application that you'll create in this walkthrough.

![Spreadsheet Application User Interface](images/FSharp_Spreadsheet.png)

This walkthrough has the following sections.


- How To: Create an F# Portable Library
<br />

- How To: Create a Silverlight App that Uses an F# Portable Library
<br />

- How To: Create a Windows Store App That Uses an F# Portable Library
<br />

- How to: Create a Desktop App That References a Portable Library That Uses F# #
<br />

## Creating a Portable Library in F# #

#### HowTo: Create an F# Portable Library

1. On the menu bar, choose **File**, **New Project**. In the **New Project** dialog box, expand **Visual F#**, choose the **F# Portable library** project type, and then name the library **Spreadsheet**. Note that the project references a special version of FSharp.Core.
<br />

2. In **Solution Explorer**, expand the References node, and then select the FSharp.Core node. In the **Properties** window, the value of the **FullPath** property should contain .NETPortable, which indicates that you're using the portable version of the Core F# library. You can also review the various .NET libraries that you can access by default. These libraries all work with a common subset of the .NET Framework that is defined as .NET portable. You can remove references that you don't need, but if you add references, your reference assembly must be available on all platforms that you're targeting. The documentation for an assembly usually indicates the platforms on which it's available.
<br />

3. Open the shortcut menu for the project, and then choose **Properties**. On the **Application** tab, the target framework is set to **.NET Portable Subset**. For Visual Studio 2012, this subset targets .NET for Windows Store apps, the .NET Framework 4.5, and Silverlight 5. These settings are important because, as a portable library, your app must run against the runtime that is available on various platforms. The runtimes for Windows Store apps and Silverlight 5 contain subsets of the full .NET Framework.
<br />

4. Rename the main code file Spreadsheet.fs, and then paste the following code into the editor window. This code defines the functionality of a basic spreadsheet.
<br />

```fsharp
  namespace Portable.Samples.Spreadsheet
  
  open System
  open System.Collections.Generic
  
  [<AutoOpen>]
  module Extensions = 
  type HashSet<'T> with
  member this.AddUnit(v) = ignore( this.Add(v) )
  
  type internal Reference = string
  
  /// Result of formula evaluation
  [<RequireQualifiedAccess>]
  type internal EvalResult = 
  | Success of obj
  | Error of string
  
  /// Function that resolves reference to value.
  /// If formula that computes value fails, this function should also return failure.
  type internal ResolutionContext = Reference -> EvalResult
  
  /// Parsed expression
  [<RequireQualifiedAccess>]
  type internal Expression = 
  | Val of obj
  | Ref of Reference
  | Op of (ResolutionContext -> list<Expression> -> EvalResult) * list<Expression>
  with 
  member this.GetReferences() = 
  match this with
  | Expression.Ref r -> Set.singleton r
  | Expression.Val _ -> Set.empty
  | Expression.Op (_, args) -> (Set.empty, args) ||> List.fold (fun acc arg -> acc + arg.GetReferences())
  
  [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
  module internal Operations = 
  
  let eval (ctx : ResolutionContext) = 
  function
  | Expression.Val v -> EvalResult.Success v
  | Expression.Ref r -> ctx r
  | Expression.Op (f, args) -> try f ctx args with e -> EvalResult.Error e.Message
  
  type private Eval = Do 
  with 
  member this.Return(v) = EvalResult.Success v
  member this.ReturnFrom(v) = v
  member this.Bind(r, f) = 
  match r with
  | EvalResult.Success v -> f v
  | EvalResult.Error _-> r
  
  let private mkBinaryOperation<'A, 'R> (op : 'A -> 'A -> 'R) ctx =
  function
  | [a; b] -> 
  Eval.Do {
  let! ra = eval ctx a
  let! rb = eval ctx b
  match ra, rb with
  | (:? 'A as ra), (:? 'A as rb) -> return op ra rb
  | _ -> return! EvalResult.Error "Unexpected type of argument"
  }
  | _ -> EvalResult.Error "invalid number of arguments"
  
  let add = mkBinaryOperation<float, float> (+)
  let sub = mkBinaryOperation<float, float> (-)
  let mul = mkBinaryOperation<float, float> (*)
  let div = mkBinaryOperation<float, float> (/)
  
  let ge = mkBinaryOperation<float, bool> (>=)
  let gt = mkBinaryOperation<float, bool> (>)
  
  let le = mkBinaryOperation<float, bool> (<=)
  let lt = mkBinaryOperation<float, bool> (<)
  
  let eq = mkBinaryOperation<IComparable, bool> (=)
  let neq = mkBinaryOperation<IComparable, bool> (<>)
  
  let mmax = mkBinaryOperation<float, float> max
  let mmin = mkBinaryOperation<float, float> min
  
  let iif ctx = 
  function
  | [cond; ifTrue; ifFalse] -> 
  Eval.Do {
  let! condValue = eval ctx cond
  match condValue with
  | :? bool as condValue-> 
  let e = if condValue then ifTrue else ifFalse
  return! eval ctx e
  | _ -> return! EvalResult.Error "Condition should be evaluated to bool"
  }
  | _ -> EvalResult.Error "invalid number of arguments"
  
  let get (name : string) = 
  match name.ToUpper() with
  | "MAX" -> mmax
  | "MIN" -> mmin
  | "IF" -> iif
  | x -> failwithf "unknown operation %s" x
  
  module internal Parser =
  let private some v (rest : string) = Some(v, rest)
  let private capture pattern text =
  let m = System.Text.RegularExpressions.Regex.Match(text, "^(" + pattern + ")(.*)")
  if m.Success then
  some m.Groups.[1].Value m.Groups.[2].Value
  else None
  let private matchValue pattern = (capture @"\s*") >> (Option.bind (snd >> capture pattern))
  
  let private matchSymbol pattern = (matchValue pattern) >> (Option.bind (snd >> Some))
  let private (|NUMBER|_|) = matchValue @"-?\d+\.?\d*"
  let private (|IDENTIFIER|_|) = matchValue @"[A-Za-z]\w*"
  let private (|LPAREN|_|) = matchSymbol @"\("
  let private (|RPAREN|_|) = matchSymbol @"\)"
  let private (|PLUS|_|) = matchSymbol @"\+"
  let private (|MINUS|_|) = matchSymbol @"-"
  let private (|GT|_|) = matchSymbol @">"
  let private (|GE|_|) = matchSymbol @">="
  let private (|LT|_|) = matchSymbol @"<"
  let private (|LE|_|) = matchSymbol @"<="
  let private (|EQ|_|) = matchSymbol @"="
  let private (|NEQ|_|) = matchSymbol @"<>"
  let private (|MUL|_|) = matchSymbol @"\*"
  let private (|DIV|_|) = matchSymbol @"/"
  let private (|COMMA|_|) = matchSymbol @","
  let private operation op args rest = some (Expression.Op(op, args)) rest
  let rec private (|Factor|_|) = function
  | IDENTIFIER(id, r) ->
  match r with
  | LPAREN (ArgList (args, RPAREN r)) -> operation (Operations.get id) args r
  | _ -> some(Expression.Ref id) r
  | NUMBER (v, r) -> some (Expression.Val (float v)) r
  | LPAREN(Logical (e, RPAREN r)) -> some e r
  | _ -> None
  
  and private (|ArgList|_|) = function
  | Logical(e, r) ->
  match r with
  | COMMA (ArgList(t, r1)) -> some (e::t) r1
  | _ -> some [e] r
  | rest -> some [] rest
  
  and private (|Term|_|) = function
  | Factor(e, r) ->
  match r with
  | MUL (Term(r, rest)) -> operation Operations.mul [e; r] rest
  | DIV (Term(r, rest)) -> operation Operations.div [e; r] rest
  | _ -> some e r
  | _ -> None
  
  and private (|Expr|_|) = function
  | Term(e, r) ->
  match r with
  | PLUS (Expr(r, rest)) -> operation Operations.add [e; r] rest
  | MINUS (Expr(r, rest)) -> operation Operations.sub [e; r] rest
  | _ -> some e r
  | _ -> None
  
  and private (|Logical|_|) = function
  | Expr(l, r) ->
  match r with
  | GE (Logical(r, rest)) -> operation Operations.ge [l; r] rest
  | GT (Logical(r, rest)) -> operation Operations.gt [l; r] rest
  | LE (Logical(r, rest)) -> operation Operations.le [l; r] rest
  | LT (Logical(r, rest)) -> operation Operations.lt [l; r] rest
  | EQ (Logical(r, rest)) -> operation Operations.eq [l; r] rest
  | NEQ (Logical(r, rest)) -> operation Operations.neq [l; r] rest
  | _ -> some l r
  | _ -> None
  
  and private (|Formula|_|) (s : string) =
  if s.StartsWith("=") then
  match s.Substring(1) with
  | Logical(l, t) when System.String.IsNullOrEmpty(t) -> Some l
  | _ -> None
  else None
  
  let parse text = 
  match text with
  | Formula f -> Some f
  | _ -> None
  
  type internal CellReference = string
  
  module internal Dependencies = 
  
  type Graph() = 
  let map = new Dictionary<CellReference, HashSet<CellReference>>()
  
  let ensureGraphHasNoCycles(cellRef) =
  let visited = HashSet()
  let rec go cycles s =
  if Set.contains s cycles then failwith ("Cycle detected:" + (String.concat "," cycles))
  if visited.Contains s then cycles
  else
  visited.AddUnit s
  if map.ContainsKey s then
  let children = map.[s]
  ((Set.add s cycles), children)
  ||> Seq.fold go
  |> (fun cycle -> Set.remove s cycles)
  else
  cycles
  
  ignore (go Set.empty cellRef)
  
  member this.Insert(cell, parentCells) = 
  for p in parentCells do
  let parentSet = 
  match map.TryGetValue p with
  | true, set -> set
  | false, _ ->
  let set = HashSet()
  map.Add(p, set)
  set
  parentSet.AddUnit cell
  try 
  ensureGraphHasNoCycles cell
  with
  _ -> 
  this.Delete(cell, parentCells)
  reraise()
  
  member this.GetDependents(cell) = 
  let visited = HashSet()
  let order = Queue()
  let rec visit curr = 
  if not (visited.Contains curr) then 
  visited.AddUnit curr
  order.Enqueue(curr)
  match map.TryGetValue curr with
  | true, children -> 
  for ch in children do
  visit ch
  | _ -> ()
  
  
  visit cell
  order :> seq<_>
  
  member this.Delete(cell, parentCells) = 
  for p in parentCells do
  map.[p].Remove(cell)
  |> ignore
  
  type Cell = 
  {
  Reference : CellReference
  Value : string
  RawValue : string
  HasError : bool
  }
  
  type RowReferences = 
  {
  Name : string
  Cells : string[]
  }
  
  type Spreadsheet(height : int, width : int) = 
  
  do 
  if height <=0 then failwith "Height should be greater than zero"
  if width <=0 || width > 26 then failwith "Width should be greater than zero and lesser than 26"
  
  let rowNames = [| for i = 0 to height - 1 do yield string (i + 1)|]
  let colNames = [| for i = 0 to (width - 1) do yield string (char (int 'A' + i)) |]
  
  let isValidReference (s : string) = 
  if s.Length < 2 then false
  else
  let c = s.[0..0]
  let r = s.[1..]
  (Array.exists ((=)c) colNames) && (Array.exists ((=)r) rowNames)
  
  let dependencies = Dependencies.Graph()
  let formulas = Dictionary<_, Expression>()
  
  let values = Dictionary()
  let rawValues = Dictionary()
  
  let setError cell text = 
  values.[cell] <- EvalResult.Error text
  
  let getValue reference = 
  match values.TryGetValue reference with
  | true, v -> v
  | _ -> EvalResult.Success 0.0
  
  let deleteValue reference = 
  values.Remove(reference)
  |> ignore
  
  let deleteFormula cell = 
  match formulas.TryGetValue cell with
  | true, expr ->
  dependencies.Delete(cell, expr.GetReferences())
  formulas.Remove(cell) 
  |> ignore
  | _ -> ()
  
  let evaluate cell = 
  let deps = dependencies.GetDependents cell
  for d in deps do
  match formulas.TryGetValue d with
  | true, e -> 
  let r = Operations.eval getValue e
  values.[d] <- r
  | _ -> ()
  deps
  
  let setFormula cell text = 
  let setError msg = 
  setError cell msg
  [cell] :> seq<_>
  
  try 
  match Parser.parse text with
  | Some expr ->
  let references = expr.GetReferences()
  let invalidReferences = [for r in references do if not (isValidReference r) then yield r]
  if not (List.isEmpty invalidReferences) then
  let msg = sprintf "Formula contains invalid references:%s" (String.concat ", " invalidReferences)
  setError msg
  else
  try
  dependencies.Insert(cell, references)
  formulas.Add(cell, expr)
  |> ignore
  evaluate cell
  with
  e -> setError e.Message
  | _ -> setError "Invalid formula text"
  with e -> setError e.Message
  
  member this.Headers = colNames
  member this.Rows = rowNames
  member this.GetRowReferences() = 
  seq { for r in rowNames do
  let cells = [| for c in colNames do yield c + r |]
  yield { Name = r; Cells = cells } }
  
  member this.SetValue(cellRef : Reference, value : string) : Cell[] = 
  rawValues.Remove(cellRef)
  |> ignore
  
  if not (String.IsNullOrEmpty value) then
  rawValues.[cellRef] <- value
  
  deleteFormula cellRef
  
  let affectedCells = 
  if (value <> null && value.StartsWith "=") then
  setFormula cellRef value
  elif String.IsNullOrEmpty value then
  deleteValue cellRef
  evaluate cellRef
  else
  match Double.TryParse value with
  | true, value -> 
  values.[cellRef] <- EvalResult.Success value
  evaluate cellRef
  | _ -> 
  values.[cellRef] <- EvalResult.Error "Number expected"
  [cellRef] :> _
  [| for r in affectedCells do 
  let rawValue = 
  match rawValues.TryGetValue r with
  | true, v -> v
  | false, _ -> ""
  
  let valueStr, hasErr = 
  match values.TryGetValue r with
  | true, (EvalResult.Success v) -> (string v), false
  | true, (EvalResult.Error msg) -> msg, true
  | false, _ -> "", false
  let c = {Reference = r; Value = valueStr; RawValue = rawValue; HasError = hasErr}
  yield c |]
```

## Using a Portable Library in a Silverlight App

#### How To: Create a Silverlight App That Uses an F# Portable Library

1. On the menu bar, choose **File**, **Add** and then **New Project**. In the **Add New Project** dialog box, expand **Visual C#**, expand **Silverlight**, and then choose **Silverlight Application**. The **New Silverlight Application** dialog box appears.
<br />

2. Make sure that the check box for **Host the Silverlight application in a new Web site** is selected, and in the drop-down, make sure that **ASP.NET Web Application Project** is selected, and then choose the **OK** button. Two projects are created: one project has the Silverlight control, and the other project is an ASP.NET web app that hosts the control.
<br />

3. Add a reference to the Spreadsheet project. Open the shortcut menu for the References node of the Silverlight project, and then choose **Add Reference**. The Reference Manager appears. Expand the Solution node, and choose the Spreadsheet project, and then choose the **OK** button.
<br />

4. In this step, you create a view model, which describes everything that the UI must do without describing how it appears. Open the shortcut menu for the project node, choose **Add**, and then choose **New Item**. Add a code file, name it ViewModel.cs, and then paste the following code into it:
<br />

```csharp
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows;
  using System.Windows.Input;
  using Portable.Samples.Spreadsheet;
  
  namespace SilverlightFrontEnd
  {
  public class SpreadsheetViewModel
  {
  private Spreadsheet spreadsheet;
  private Dictionary<string, CellViewModel> cells = new Dictionary<string, CellViewModel>();
  
  public List<RowViewModel> Rows { get; private set; }
  public List<string> Headers { get; private set; }
  
  
  public string SourceCode
  {
  get
  {
  return @"
  type Spreadsheet(height : int, width : int) = 
  
  do 
  if height <= 0 then failwith ""Height should be greater than zero""
  if width <= 0 || width > 26 then failwith ""Width should be greater than zero and lesser than 26""
  
  let rowNames = [| for i = 0 to height - 1 do yield string (i + 1)|]
  let colNames = [| for i = 0 to (width - 1) do yield string (char (int 'A' + i)) |]
  
  let isValidReference (s : string) = 
  if s.Length < 2 then false
  else
  let c = s.[0..0]
  let r = s.[1..]
  (Array.exists ((=)c) colNames) && (Array.exists ((=)r) rowNames)
  
  let dependencies = Dependencies.Graph()
  let formulas = Dictionary<_, Expression>()
  
  let values = Dictionary()
  let rawValues = Dictionary()
  
  let setError cell text = 
  values.[cell] <- EvalResult.E text
  
  let getValue reference = 
  match values.TryGetValue reference with
  | true, v -> v
  | _ -> EvalResult.S 0.0
  
  let deleteValue reference = 
  values.Remove(reference)
  |> ignore
  
  let deleteFormula cell = 
  match formulas.TryGetValue cell with
  | true, expr ->
  dependencies.Delete(cell, expr.GetReferences())
  formulas.Remove(cell) 
  |> ignore
  | _ -> ()
  ";
  }
  }
  
  public SpreadsheetViewModel(Spreadsheet spreadsheet)
  {
  this.spreadsheet = spreadsheet;
  Rows = new List<RowViewModel>();
  foreach (var rowRef in spreadsheet.GetRowReferences())
  {
  var rowvm = new RowViewModel { Index = rowRef.Name, Cells = new List<CellViewModel>() };
  
  foreach (var reference in rowRef.Cells)
  {
  var cell = new CellViewModel(this, reference);
  cells.Add(reference, cell);
  rowvm.Cells.Add(cell);
  }
  Rows.Add(rowvm);
  
  }
  Headers = new[] { "  " }.Concat(spreadsheet.Headers).ToList();
  }
  
  public void SetCellValue(string reference, string newText)
  {
  var affectedCells = spreadsheet.SetValue(reference, newText);
  foreach (var cell in affectedCells)
  {
  var cellVm = cells[cell.Reference];
  cellVm.RawValue = cell.RawValue;
  
  if (cell.HasError)
  {
  cellVm.Value = "#ERROR";
  cellVm.Tooltip = cell.Value; // will contain error
  }
  else
  {
  cellVm.Value = cell.Value;
  cellVm.Tooltip = cell.RawValue;
  }
  }
  }
  }
  
  public class RowViewModel
  {
  public string Index { get; set; }
  public List<CellViewModel> Cells { get; set; }
  }
  
  public class CellViewModel : INotifyPropertyChanged
  {
  private SpreadsheetViewModel spreadsheet;
  
  private string rawValue;
  private string value;
  private string reference;
  private string tooltip;
  
  public CellViewModel(SpreadsheetViewModel spreadsheet, string reference)
  {
  this.spreadsheet = spreadsheet;
  this.reference = reference;
  }
  
  public string RawValue
  {
  get
  {
  return rawValue;
  }
  set
  {
  var changed = rawValue != value;
  rawValue = value;
  if (changed) RaisePropertyChanged("RawValue");
  }
  }
  public string Value
  {
  get
  {
  return value;
  }
  set
  {
  var changed = this.value != value;
  this.value = value;
  if (changed) RaisePropertyChanged("Value");
  }
  }
  public string Tooltip
  {
  get
  {
  return tooltip;
  }
  set
  {
  var changed = this.tooltip != value;
  this.tooltip = value;
  if (changed)
  {
  RaisePropertyChanged("Tooltip");
  RaisePropertyChanged("TooltipVisibility");
  }
  }
  }
  
  public Visibility TooltipVisibility
  {
  get { return string.IsNullOrEmpty(tooltip) ? Visibility.Collapsed : Visibility.Visible; }
  }
  
  public event PropertyChangedEventHandler PropertyChanged = delegate { };
  
  public void SetCellValue(string newValue)
  {
  spreadsheet.SetCellValue(reference, newValue);
  }
  
  private void RaisePropertyChanged(string name)
  {
  PropertyChanged(this, new PropertyChangedEventArgs(name));
  }
  }
  }
```

5. In the Silverlight control project, open MainPage.xaml, which declares the UI layout for the main spreadsheet. In MainPage.xaml, paste the following XAML code into the existing Grid element.
<br />

```xml
  <TextBlock Text="{Binding SourceCode}" FontSize="20" FontFamily="Consolas" Foreground="LightGray"/>
  <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
  <StackPanel.Resources>
  <Style x:Key="CellBorder" TargetType="Border">
  <Setter Property="BorderThickness" Value="0.5"/>
  <Setter Property="BorderBrush" Value="LightGray"/>
  </Style>
  <Style x:Key="CaptionBorder" TargetType="Border" BasedOn="{StaticResource CellBorder}">
  <Setter Property="Background" Value="LightBlue"/>
  </Style>
  <Style x:Key="TextContainer" TargetType="TextBlock">
  <Setter Property="FontSize" Value="26"/>
  <Setter Property="FontFamily" Value="Segoe UI"/>
  <Setter Property="Width" Value="200"/>
  <Setter Property="Height" Value="60"/>
  </Style>
  
  <Style x:Key="CaptionText" TargetType="TextBlock" BasedOn="{StaticResource TextContainer}">
  <Setter Property="TextAlignment" Value="Center"/>
  <Setter Property="Foreground" Value="DimGray"/>
  </Style>
  <Style x:Key="ValueEditor" TargetType="TextBox">
  <Setter Property="Width" Value="200"/>
  <Setter Property="Height" Value="60"/>
  <Setter Property="FontSize" Value="26"/>
  <Setter Property="FontFamily" Value="Segoe UI"/>
  
  </Style>
  <Style x:Key="ValueText" TargetType="TextBlock" BasedOn="{StaticResource TextContainer}">
  <Setter Property="TextAlignment" Value="Center"/>
  <Setter Property="VerticalAlignment" Value="Center"/>
  <Setter Property="Foreground" Value="Black"/>
  </Style>
  
  </StackPanel.Resources>
  <Border Style="{StaticResource CellBorder}">
  <StackPanel>
  
  <ItemsControl ItemsSource="{Binding Headers}">
  <ItemsControl.ItemsPanel>
  <ItemsPanelTemplate>
  <VirtualizingStackPanel Orientation="Horizontal" />
  </ItemsPanelTemplate>
  </ItemsControl.ItemsPanel>
  <ItemsControl.ItemTemplate>
  <DataTemplate>
  <Border Style="{StaticResource CaptionBorder}">
  <TextBlock Text="{Binding}" Style="{StaticResource CaptionText}"/>
  </Border>
  </DataTemplate>
  </ItemsControl.ItemTemplate>
  </ItemsControl>
  
  <ItemsControl ItemsSource="{Binding Rows}">
  <ItemsControl.ItemTemplate>
  <DataTemplate>
  <StackPanel Orientation="Horizontal">
  <Border Style="{StaticResource CaptionBorder}">
  <TextBlock Text="{Binding Index}" Style="{StaticResource CaptionText}"/>
  </Border>
  <ItemsControl ItemsSource="{Binding Cells}">
  <ItemsControl.ItemsPanel>
  <ItemsPanelTemplate>
  <VirtualizingStackPanel  Orientation="Horizontal"/>
  </ItemsPanelTemplate>
  </ItemsControl.ItemsPanel>
  <ItemsControl.ItemTemplate>
  <DataTemplate>
  <Border Style="{StaticResource CellBorder}">
  <Grid>
  <TextBox
  Name="editor"
  Tag="{Binding ElementName=textContainer}"
  Visibility="Collapsed"
  LostFocus="OnLostFocus"
  KeyUp="OnKeyUp"
  Text ="{Binding RawValue}"
  Style="{StaticResource ValueEditor}"/>
  <TextBlock
  Name="textContainer"
  Tag="{Binding ElementName=editor}"
  Visibility="Visible"
  Text="{Binding Value}"
  Style="{StaticResource ValueText}"
  MouseLeftButtonDown="OnMouseLeftButtonDown"
  ToolTipService.Placement="Mouse">
  <ToolTipService.ToolTip>
  <ToolTip Visibility="{Binding TooltipVisibility}">
  <TextBlock Text="{Binding Tooltip}" Style="{StaticResource TextContainer}" Visibility="{Binding TooltipVisibility}"/>
  </ToolTip>
  </ToolTipService.ToolTip>
  </TextBlock>
  </Grid>
  </Border>
  </DataTemplate>
  </ItemsControl.ItemTemplate>
  </ItemsControl>
  </StackPanel>
  </DataTemplate>
  </ItemsControl.ItemTemplate>
  </ItemsControl>
  
  </StackPanel>
  </Border>
  </StackPanel>
```

6. In MainPage.xaml.cs, add `using SilverlightFrontEnd;` to the list of using directives, and then add the following methods to the `SilverlightApplication1` class.
<br />

```csharp
  void OnLostFocus(object sender, RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  }
  
  void OnKeyUp(object sender, KeyEventArgs e)
  {
  if (e.Key == Key.Escape)
  {
  HideEditor(e);
  e.Handled = true;
  return;
  }
  else if (e.Key == Key.Enter)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  e.Handled = true;
  }
  }
  
  private void EditValue(object dataContext, string newText)
  {
  var cvm = (CellViewModel)dataContext;
  cvm.SetCellValue(newText);
  }
  
  private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
  {
  var textBlock = (TextBlock)e.OriginalSource;
  var editor = (TextBox)textBlock.Tag;
  textBlock.Visibility = Visibility.Collapsed;
  editor.Visibility = Visibility.Visible;
  editor.Focus();
  }
  
  private void HideEditor(RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var textBlock = (TextBlock)editor.Tag;
  editor.Visibility = Visibility.Collapsed;
  textBlock.Visibility = Visibility.Visible;
  }
```

7. In App.xaml.cs, add the following using directives to it:
<br />

```csharp
  using SilverlightFrontEnd;
  using Portable.Samples.Spreadsheet;
```

  Paste the following code into the **Application_Startup** event handler:
<br />

```csharp
  var spreadsheet = new Spreadsheet(5, 5);
  var spreadsheetViewModel = new SpreadsheetViewModel(spreadsheet);
  var main = new MainPage();
  main.DataContext = spreadsheetViewModel;
  this.RootVisual = main;
```

8. You can test your Silverlight front end by either starting the Silverlight project directly or by starting the ASP.NET web app that hosts the Silverlight control. Open the shortcut menu for the node for either of those projects, and then choose **Set As Startup Project**.
<br />

## Using the Portable Library in a Windows Store App

#### How To: Create a Windows Store App That Uses an F# Portable Library

1. In this section, you'll create a Windows Store app that uses the F# spreadsheet code as its computational component. On the menu bar, choose **File**, **Add**, **New Project**. The **New Project** dialog box appears. Under **Installed**, expand **Visual C#**, expand **Windows Store**, and then choose the **Blank App** template. Name the project NewFrontEnd, and then choose the **OK** button. If prompted for your developer license to create Windows Store apps, enter your credentials. If you don't have credentials, you can find out how to set them up [here](http://go.microsoft.com/fwlink/?LinkId=249092).
<br />  The project is created. Note the configuration and contents of this project. The default References include .NET for Windows Store apps, which is the subset of the .NET Framework that's compatible with Windows Store apps, and the Windows assembly, which includes the APIs for the Windows Runtime and the UI for Windows Store apps. The Assets and Common subfolders have been created. The Assets subfolder contains several icons that apply to Windows Store apps, and the Common subfolder contains shared routines that templates for Windows Store apps use. The default project template has also created App.xaml, BlankPage.xaml, and their associated C# code-behind files, App.xaml.cs and BlankPage.xaml.cs. App.xaml describes the overall app, and BlankPage.xaml describes its one defined UI surface. Finally, any .pfx files and .appxmanifest files support the security and deployment models for Windows Store apps.
<br />

2. Add a reference to the Spreadsheet project by opening the shortcut menu for the References node of the Silverlight project and choosing **Add Reference**. In the Reference Manager, expand the Solution node, choose the Spreadsheet project, and then choose the **OK** button.
<br />

3. You'll need some of the code that you already used in the Silverlight project to support the code for the UI of the Windows Store app. This code is in ViewModels.cs. Open the shortcut menu for the project node for NewFrontEnd, choose **Add**, and then choose **New Item**. Add a C# code file, and name it ViewModels.cs. Paste the code from ViewModels.cs in the Silverlight project, and then change the block of using directives at the top of this file. Remove System.Windows, which is used for the Silverlight UI, and add Windows.UI.Xaml and Windows.Foundation.Collections, which are used for the UI of the Windows Store app. Both Silverlight and the Windows Store UI are based on WPF, so they're compatible with each other. The updated block of using directives should resemble the following example:
<br />

```csharp
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows.Input;
  using Portable.Samples.Spreadsheet;
  using Windows.Foundation.Collections;
  using Windows.UI.Xaml;
```

Also, change the namespace in ViewModels.cs from SilverlightFrontEnd to NewFrontEnd.
<br />  

You can reuse the rest of the code in ViewModels.cs, but some types, such as Visibility, are now the versions for Windows Store apps instead of Silverlight.
<br />

4. In this Windows Store app, the App.xaml.cs code file must have similar startup code as that which appeared in the `Application_Startup` event handler for the Silverlight app. In a Windows Store app, this code appears in the `OnLaunched` event handler of the App class. Add the following code to the `OnLaunched` event handler in App.xaml.cs:
<br />

```csharp
  var spreadsheet = new Spreadsheet(5, 5);
  var spreadsheetViewModel = new SpreadSheetViewModel(spreadsheet);
```

5. Add a using directive for the Spreadsheet code.
<br />

```csharp
  using Portable.Samples.Spreadsheet;
```

6. In App.xaml.cs, `OnLaunched` contains code that specifies what page to load. You'll add a page that you want the app to load when a user starts it. Change the code in `OnLaunched` to navigate to the first page, as the following example shows:
<br />

```csharp
  // Create a frame, and navigate to the first page.
  var rootFrame = new Frame();
  rootFrame.Navigate(typeof(ItemsPage1), spreadsheetViewModel);
```

You can delete BlankPage1.xaml and its code-behind file because they're not used in this example.
<br />

7. Open the shortcut menu for the project node for NewFrontEnd, choose **Add**, and then choose **New Item**. Add an Items Page, and retain the default name, ItemsPage1.xaml. This step adds both ItemsPage1.xaml and its code-behind file, ItemsPage1.xaml.cs, to the project. ItemsPage1.xaml starts with a main tag of **common:LayoutAwarePage** with many attributes, as the following XAML code shows:
<br />

```xml
  <common:LayoutAwarePage
  x:Name="pageRoot"
  x:Class="NewFrontEnd.ItemsPage1"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:local="using:NewFrontEnd"
  xmlns:common="using:NewFrontEnd.Common"
  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
  mc:Ignorable="d">
```

The UI for the Windows Store app is identical to the UI for the Silverlight app that you created, and the XAML format is the same in this case. Therefore, you can reuse the XAML from MainPage.xaml in the Silverlight project for ItemsPage1.xaml in the UI for the Windows Store app.
<br />

8. Copy the code within the top-level Grid element of MainPage.xaml for the Silverlight project, and paste it into the top-level Grid element in ItemsPage1.xaml in the project for the UI of the Windows Store app. When you paste the code, you can overwrite any existing contents of the Grid element. Change the Background attribute on the Grid element to "White," and replace `MouseLeftButtonDown` with `PointerPressed`.
<br />  The name of this event differs in Silverlight apps and Windows Store apps.
<br />

9. In ItemsPage.xaml.cs, set the `DataContext` property by changing the `OnNavigatedTo` method.
<br />

```csharp
  protected override void OnNavigatedTo(NavigationEventArgs e)
  {
  this.DataContext = e.Parameter;
  }
```

10. Copy the following event-handler code, and paste it into the ItemsPage1 class: `OnLostFocus`, `OnKeyUp`, `EditValue`, `OnPointerPressed`, and `HideEditor`.
<br />

```csharp
  void OnLostFocus(object sender, RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  }
  
  void OnKeyUp(object sender, KeyEventArgs e)
  {
  if (e.Key == Windows.System.VirtualKey.Escape)
  {
  HideEditor(e);
  e.Handled = true;
  return;
  }
  else if (e.Key == Windows.System.VirtualKey.Enter)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  e.Handled = true;
  }            
  }
  
  private void EditValue(object dataContext, string newText)
  {
  var cvm = (CellViewModel)dataContext;
  cvm.SetCellValue(newText);
  }
  
  private void OnPointerPressed(object sender, RoutedEventArgs e)
  {
  var textBlock = (TextBlock)e.OriginalSource;
  var editor = (TextBox)textBlock.Tag;
  textBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
  editor.Visibility = Windows.UI.Xaml.Visibility.Visible;
  
  editor.Focus(FocusState.Programmatic);
  }
  
  private void HideEditor(RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var textBlock = (TextBlock)editor.Tag;
  editor.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
  textBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
  }
```

11. Change the startup project to the project for your Windows Store app. Open the shortcut menu for the NewFrontEnd project node, choose **Set As Startup Project**, and then choose the F5 key to run the project.
<br />

## Creating a Portable Library in C# that Uses F# #
The previous sample duplicates code in that the ViewModels.cs code appears in multiple projects. In this section, you create a C# Portable Library project to contain this code. In some cases, you must add information to the configuration file of an app when it consumes portable libraries that use F#. In this case, a desktop app, which targets the desktop version of the .NET Framework 4.5, references a C# portable library that, in turn, references an F# portable library. In such a case, you must add a binding redirect to the app.config file of the main app. You must add this redirect because only one version of the FSharp.Core library is loaded, but the portable libraries reference the .NET Portable version. Any calls to the .NET Portable versions of FSharp.Core functions must be redirected to the single version of FSharp.Core that's loaded in a desktop app. The binding redirects are necessary only in the desktop app, because the runtime environments for Silverlight 5 and Windows Store apps use the .NET Portable version of FSharp.Core, not the full desktop version.


#### How to: Create a Desktop App That References a Portable Library That Uses F# #

1. On the menu bar, choose **File**, **Add**, **New Project**. Under **Installed**, expand the **Visual C#** node, choose the **.NET Portable Library** project template, and then name the project **ViewModels**.
<br />

2. You must set the targets for this .NET Portable library to match the F# Portable Library to which you'll add a reference. Otherwise, an error message will inform you of the mismatch. On the shortcut menu for the ViewModels project, choose **Properties**. On the **Library** tab, change the targets for this portable library to match the .NET Framework 4.5, Silverlight 5, and Windows Store apps.
<br />

3. On the shortcut menu for the **References** node, choose **Add Reference**. Under **Solution**, select the check box next to Spreadsheet.
<br />

4. Copy the code for ViewModels.cs from one of the other projects, and paste it in the code file for the ViewModels project.
<br />

5. Make the following changes, which make the code in ViewModels completely independent of the UI platform:
<br />
  1. Remove using directives for System.Windows, System.Windows.Input, Windows.Foundation.Collections, and Windows.UI.Xaml, if present.
<br />

  2. Change the namespace to ViewModels.
<br />

  3. Remove the `TooltipVisibility` property. This property uses Visibility, which is a platform-dependent object.
<br />

6. On the menu bar, choose **File**, **Add**, **New Project**. Under **Installed**, expand the **Visual C#** node, and then choose the **WPF Application** project template. Name the new project **Desktop**, and choose the **OK** button.
<br />

7. Open the shortcut menu for the **References** node in the Desktop project, and then choose **Add Reference**. Under **Solution**, choose the Spreadsheet and ViewModels projects.
<br />

8. Open the app.config file for the WPF app, and then add the following lines of code. This code configures the appropriate binding redirects that apply when a desktop app that targets .NET Framework 4.5 references a .NET Portable Library that uses F#. The .NET Portable libraries use version 2.3.5.0 of the FSharp.Core library, and the .NET Framework 4.5 desktop apps use version 4.3.0.0.
<br />

```xml
  <?xml version="1.0" encoding="utf-8" ?>
  <configuration>
  <startup> 
  <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <runtime>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
  <dependentAssembly>
  <assemblyIdentity name="FSharp.Core" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
  <bindingRedirect oldVersion="2.3.5.0" newVersion="4.3.0.0"/>
  </dependentAssembly>
  </assemblyBinding>
  </runtime>
  </configuration>
```

Now you must add a reference to the portable version of the F# Core library. This reference is required whenever you have an application that consumes a portable library that references an F# portable library.
<br />

9. Open the shortcut menu for the **References** node in the Desktop project, and then choose **Add Reference**. Choose **Browse**, and then navigate to Reference Assemblies\Microsoft\FSharp\3.0\Runtime\.NETPortable\FSharp.Core.dll under the Program Files folder where Visual Studio is installed.
<br />

10. In the Desktop project, add using directives for ViewModels.cs and Portable.Samples.Spreadsheet to App.xaml.cs and MainWindow.xaml.cs.
<br />

```csharp
  using ViewModels;
  using Portable.Samples.Spreadsheet;
```

11. Open the MainWindow.xaml file, and then change the title attribute of the Window class to **Spreadsheet**.
<br />

12. Copy the code within the Grid element of MainPage.xaml in the Silverlight project, and paste that code into the Grid element of MainWindow.xaml in the Desktop project.
<br />

13. Copy the event-handling code in MainPage.xaml.cs from the Silverlight project, and paste that code into MainWindow.xaml.cs in the Desktop project.
<br />

```csharp
  void OnLostFocus(object sender, RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  }
  
  void OnKeyUp(object sender, KeyEventArgs e)
  {
  if (e.Key == Key.Escape)
  {
  HideEditor(e);
  e.Handled = true;
  return;
  }
  else if (e.Key == Key.Enter)
  {
  var editor = (TextBox)e.OriginalSource;
  var text = editor.Text;
  
  HideEditor(e);
  
  EditValue(editor.DataContext, text);
  e.Handled = true;
  }
  }
  
  private void EditValue(object dataContext, string newText)
  {
  var cvm = (CellViewModel)dataContext;
  cvm.SetCellValue(newText);
  }
  
  private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
  {
  var textBlock = (TextBlock)e.OriginalSource;
  var editor = (TextBox)textBlock.Tag;
  textBlock.Visibility = Visibility.Collapsed;
  editor.Visibility = Visibility.Visible;
  editor.Focus();
  }
  
  private void HideEditor(RoutedEventArgs e)
  {
  var editor = (TextBox)e.OriginalSource;
  var textBlock = (TextBlock)editor.Tag;
  editor.Visibility = Visibility.Collapsed;
  textBlock.Visibility = Visibility.Visible;
  }
```

14. Add the spreadsheet startup code to the MainWindow constructor in MainWindow.xaml.cs, and replace references to MainPage with references to MainWindow.
<br />

```csharp
  public MainWindow()
  {
  var spreadsheet = new Spreadsheet(5, 5);
  var spreadsheetViewModel = new SpreadsheetViewModel(spreadsheet);
  
  
  this.DataContext = spreadsheetViewModel;
  InitializeComponent();
  }
```

15. Open the shortcut menu for the Desktop project, and then choose **Set as Startup Project**.
<br />

16. Choose the F5 key to build the app, and then debug it.
<br />


## Next Steps
As an alternative, you can modify the projects for the Windows Store app and the Silverlight app to use the new ViewModels portable library.

Continue to learn about Windows Store apps at the [Windows Developer Center](http://go.microsoft.com/fwlink/?LinkId=247417).


## See Also
[Visual F&#35; Samples and Walkthroughs](Visual-FSharp-Samples-and-Walkthroughs.md)

[Universal Windows Apps &#40;C--&#41;](https://msdn.microsoft.com/library/hh875012.aspx)

[Silverlight](http://go.microsoft.com/fwlink/?LinkId=247415)

[Cross-Platform Development with the Portable Class Library](https://msdn.microsoft.com/library/gg597391.aspx)