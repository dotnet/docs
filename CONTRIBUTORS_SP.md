Vielen Dank für Ihr Interesse an einem Beitrag zur . NET-Dokumentation! 

Wir sind dabei, unsere Richtlinien in einen standortweiten Beitragsleitfaden zu überführen. Um die neue Anleitung zu sehen, besuchen Sie die Übersicht der Microsoft Docs Contributor Guide. 

Das Dokument deckt den Prozess für den Beitrag zu den Artikeln und Code-Beispielen ab, die auf der. NET-Dokumentationsseite gehostet werden. Beiträge können so einfach wie Tippfehler-Korrekturen oder so komplex wie neue Artikel sein. 

Verfahren zum Beitragen 
Das interaktive C#-Erlebnis 
DOs und DON'Ts 
Lizenzvereinbarung für Mitwirkende 
Dieses Repository enthält die konzeptionelle Dokumentation für . NET. Die . NET-Dokumentationsseite besteht aus mehreren zusätzlichen Repositories: 

Code-Beispiele und Ausschnitte 
API-Referenz 
. NET Compiler Plattform SDK Referenz
Probleme und Aufgaben für alle diese Repositories werden hier verfolgt. 

Verfahren zum Beitragen 
Du brauchst ein grundlegendes Verständnis von Git und GitHub. com. 

Schritt 1: Überspringen Sie diesen Schritt für kleine Änderungen. Wenn Sie daran interessiert sind, neue Inhalte zu schreiben oder bestehende Inhalte gründlich zu überarbeiten, öffnen Sie eine Ausgabe, die beschreibt, was Sie tun möchten. Der Inhalt im Ordner docs ist in Abschnitte unterteilt, die im Inhaltsverzeichnis (TOC) enthalten sind. Definieren Sie, wo sich das Thema im TOC befinden soll. Erhalten Sie Feedback zu Ihrem Vorschlag. 

-oder- 

Sie können auch aus bestehenden Themen wählen, zu denen Gemeinschaftsbeiträge willkommen sind. Projekte für . NET Community-Mitwirkende listet viele der Arbeitsaufgaben auf, die für Community-Mitwirkende verfügbar sind. Abhängig von Ihren Interessen und Ihrem Engagement können Sie aus Themen in den folgenden Kategorien wählen:
Wartung. Diese Kategorie umfasst ziemlich einfache Beiträge, wie z. B. das Beheben von defekten oder falschen Links, das Hinzufügen von fehlenden Codebeispielen oder das Beheben von Problemen mit begrenzten Inhalten. In einigen Fällen können diese Probleme eine große Anzahl von Dateien betreffen. In diesem Fall sollten Sie uns vorab mitteilen, woran Sie arbeiten möchten. 

Aktualisierung der Inhalte. Angesichts der Größe des Dokumentsatzes werden Inhalte leicht veraltet und müssen überarbeitet werden. Darüber hinaus wurden aus verschiedenen Gründen einige Inhalte dupliziert oder sogar verdreifacht. Die Aktualisierung von Inhalten beinhaltet die Sicherstellung der Aktualität einzelner Themen oder die Überarbeitung von Inhalten in einem Funktionsbereich, um Doppelarbeit zu vermeiden und sicherzustellen, dass alle eindeutigen Inhalte in dem kleineren Dokumentationssatz erhalten bleiben. 

Neue Inhaltserstellung. Wenn Sie daran interessiert sind, Ihr eigenes Thema zu verfassen, werden in diesen Themen Themen aufgelistet, von denen wir wissen, dass wir sie zu unserem Doku-Set hinzufügen möchten. Lassen Sie es uns jedoch wissen, bevor Sie mit der Bearbeitung eines Themas beginnen. Wenn Sie daran interessiert sind, ein Thema zu schreiben, das hier nicht aufgeführt ist, öffnen Sie ein Problem. 

Sie können sich auch unsere Liste der offenen Fragen ansehen und sich freiwillig an denjenigen beteiligen, die Sie interessieren. Wir verwenden das Up-for-Grabs-Label, um offene Themen für Beiträge zu kennzeichnen. 

Schritt 2: Verzweigen Sie die /dotnet/docs, dotnet/samples oder dotnet/dotnet-api-docs repos nach Bedarf und erstellen Sie einen Zweig für Ihre Änderungen. 

Für kleinere Änderungen können Sie die Weboberfläche von GitHub verwenden. Klicken Sie einfach auf die Schaltfläche Edit the file in Ihrem Fork dieses Projekts auf die Datei, die Sie ändern möchten. GitHub erstellt den neuen Zweig für Sie, wenn Sie die Änderungen einreichen.
1529 / 2048
Service provided by  DeepL
Schritt 3: Nehmen Sie die Änderungen an diesem neuen Zweig vor. 

Wenn es sich um ein neues Thema handelt, können Sie diese Vorlagendatei als Ausgangspunkt verwenden. Es enthält die Schreibrichtlinien und erklärt auch die für jeden Artikel erforderlichen Metadaten, wie z. B. Autoreninformationen. 

Navigieren Sie zu dem Ordner, der dem TOC-Speicherort entspricht, der für Ihren Artikel in Schritt 1 festgelegt wurde. Dieser Ordner enthält die Markdown-Dateien für alle Artikel in diesem Abschnitt. Erstellen Sie bei Bedarf einen neuen Ordner, um die Dateien für Ihren Inhalt zu platzieren. Der Hauptartikel für diesen Abschnitt heißt index. md. Erstellen Sie für Bilder und andere statische Ressourcen einen Unterordner namens media in dem Ordner, der Ihren Artikel enthält, wenn er nicht bereits vorhanden ist. Erstellen Sie innerhalb des Medienordners einen Unterordner mit dem Artikelnamen (außer der Indexdatei). Nehmen Sie größere Samples in den Ordner samples unter dem Stammverzeichnis des Repos auf. 

Achten Sie darauf, dass Sie die richtige Markdown-Syntax befolgen. Weitere Informationen finden Sie im Style Guide. 

Beispielstruktur 
Dokumente 
über 
/Kern 
/porting 
porting-overview. md 
/medien 
/porting-Übersicht 
Portabilität_Bericht. png 
Schritt 4: Senden Sie einen Pull Request (PR) von Ihrer Niederlassung an dotnet/docs/master. 

Jede PR sollte in der Regel immer nur ein Thema auf einmal ansprechen. Der PR kann eine oder mehrere Dateien ändern. Wenn Sie mehrere Fixes in verschiedenen Dateien beheben, werden separate PRs bevorzugt. 

Wenn Ihr PR ein bestehendes Problem behebt, fügen Sie das Schlüsselwort Fixes #Issue_Number der Commit-Nachricht oder PR-Beschreibung hinzu. Auf diese Weise wird das Problem automatisch geschlossen, wenn der PR zusammengeführt wird. Weitere Informationen finden Sie unter Schließen von Problemen über Commit-Meldungen. 

Das . NET-Team wird Ihren PR überprüfen und Sie darüber informieren, ob es weitere Aktualisierungen/Änderungen gibt, die notwendig sind, um ihn zu genehmigen. 

Schritt 5: Nehmen Sie alle notwendigen Updates für Ihre Niederlassung vor, wie mit dem Team besprochen. 

Die Betreuer werden Ihre PR in der Masterbranche zusammenführen, sobald das Feedback angewendet wurde und Ihre Änderung genehmigt wurde.
1926 / 2048
Service provided by  DeepL
Ab einer bestimmten Kadenz schieben wir alle Commits vom Master-Zweig in den Live-Zweig und dann können Sie Ihren Beitrag live unter https://docs. microsoft. com/dotnet/. sehen. 

Beitrag zu den Stichproben 
Wir machen die folgende Unterscheidung für Code, der in unserem Repository existiert: 

Proben: Leser können die Proben herunterladen und ausführen. Alle Beispiele sollten vollständige Anwendungen oder Bibliotheken sein. Wenn das Beispiel eine Bibliothek erstellt, sollte es Komponententests oder eine Anwendung beinhalten, mit der Leser den Code ausführen können. 

Ausschnitte: Veranschaulichung eines kleineren Konzepts oder einer kleineren Aufgabe. Sie kompilieren, sind aber nicht als vollständige Anwendungen gedacht. 

Code all lives in the dotnet/samples repository. Wir arbeiten an einem Modell, bei dem unsere Musterordnerstruktur mit unserer docs Ordnerstruktur übereinstimmt. Die Standards, die wir befolgen, sind: 

Der Ordner Snippets auf höchster Ebene enthält Snippets für kleine, fokussierte Samples. 
API-Referenzproben befinden sich in einem Ordner nach folgendem Muster: snippets//api//>. 
Andere übergeordnete Ordner entsprechen den übergeordneten Ordnern im docs-Repository. Beispielsweise hat das docs-Repository einen Ordner für maschinelles Lernen/Tutorials, und die Beispiele für maschinelles Lernen befinden sich im Ordner samples/machine-learning/tutorials. 
Darüber hinaus sollten alle Samples unter den Core- und Standardordnern auf allen Plattformen, die von . NET Core unterstützt werden, erstellt und ausgeführt werden. Unser CI-Build-System wird dies durchsetzen. Der Framework-Ordner der obersten Ebene enthält Beispiele, die nur unter Windows erstellt und validiert werden. 

Wir können diese Verzeichnisse erweitern, wenn das docs-Repository neue Inhalte hinzufügt. Zum Beispiel werden wir Xamarin-Verzeichnisse hinzufügen, wie xamarin-ios und xamarin-android-Verzeichnisse.
1664 / 2048
Service provided by  DeepL
Jedes komplette Sample, das Sie erstellen, sollte eine readme. md-Datei enthalten. Diese Datei sollte eine kurze Beschreibung der Probe enthalten (ein oder zwei Absätze). Ihre readme. md sollte den Lesern sagen, was sie lernen werden, wenn sie sich dieses Beispiel ansehen. Die Datei readme. md sollte auch einen Link zum Live-Dokument auf der . NET-Dokumentationsseite enthalten. Um festzustellen, wo eine bestimmte Datei im Repository dieser Site zugeordnet ist, ersetzen Sie /docs im Repository-Pfad durch http://docs. microsoft. com/dotnet/articles. 

Dein Thema wird auch Links zu dem Beispiel enthalten. Verlinken Sie direkt auf den Ordner des Samples auf GitHub. 

Weitere Informationen finden Sie in der Readme der Samples. 

Das interaktive C#-Erlebnis 
Kurze Code-Beispiele in C# können mit dem Tag csharp-interactive language ein C#-Beispiel angeben, das im Browser läuft. (Inline-Code-Beispiele verwenden das csharp-interaktive Tag, für Ausschnitte aus dem Quellcode das code-csharp-interaktive Tag. ) Diese Codemuster zeigen ein Codefenster und ein Ausgabefenster im Artikel. Das Ausgabefenster zeigt alle Ausgaben von der Ausführung des interaktiven Codes an, sobald der Benutzer das Beispiel ausgeführt hat.
1095 / 2048
Service provided by  DeepL
Die interaktive C#-Erfahrung verändert die Art und Weise, wie wir mit Samples arbeiten. Besucher können die Stichprobe ausführen, um die Ergebnisse zu sehen. Eine Reihe von Faktoren helfen zu bestimmen, ob das Muster oder der entsprechende Text Informationen über die Ausgabe enthalten soll. 

Wann soll die erwartete Ausgabe angezeigt werden, ohne das Sample zu starten? 
Artikel, die für Anfänger gedacht sind, sollten Ausgaben bereitstellen, damit die Leser den Output ihrer Arbeit mit der erwarteten Antwort vergleichen können. 
Proben, bei denen die Ausgabe integraler Bestandteil des Themas ist, sollten diese Ausgabe anzeigen. Beispielsweise sollten Artikel über formatierten Text das Textformat anzeigen, ohne das Beispiel auszuführen. 
Wenn sowohl die Stichprobe als auch die erwartete Ausgabe kurz sind, sollten Sie die Ausgabe anzeigen. Es spart ein wenig Zeit. 
Artikel, die erklären, wie die aktuelle Kultur oder die invariante Kultur die Produktion beeinflusst, sollten die erwartete Produktion erklären. Der interaktive REPL (Read Evaluate Print Loop) läuft auf einem Linux-basierten Host. Die Standardkultur und die invariante Kultur erzeugen unterschiedliche Ergebnisse auf verschiedenen Betriebssystemen und Maschinen. Der Artikel sollte die Ausgabe auf Windows-, Linux- und Mac-Systemen erklären. 
Wann soll die erwartete Ausgabe von der Stichprobe ausgeschlossen werden? 
Artikel, bei denen die Stichprobe eine größere Ausgabe erzeugt, sollten diese nicht in Kommentare aufnehmen. Es verdeckt den Code, sobald das Sample ausgeführt wurde. 
Artikel, bei denen das Beispiel ein Thema demonstriert, die Ausgabe aber nicht zum Verständnis beiträgt. Beispielsweise Code, der eine LINQ-Abfrage ausführt, um die Abfragesyntax zu erklären und dann jedes Element in der Ausgabesammlung anzuzeigen. 
DOs und DON'Ts 
Die folgende Liste zeigt einige Leitregeln, die Sie beachten sollten, wenn Sie zur . NET-Dokumentation beitragen:
Überraschen Sie uns NICHT mit großen Pull-Anfragen. Stattdessen sollten Sie ein Problem einreichen und eine Diskussion beginnen, damit wir uns auf eine Richtung einigen können, bevor Sie viel Zeit investieren. 
Lesen Sie den Style Guide und die Sprach- und Tonrichtlinien. 
Verwenden Sie die Vorlagendatei als Ausgangspunkt für Ihre Arbeit. 
Erstellen Sie vor der Bearbeitung der Artikel einen separaten Ast an Ihrer Gabel. 
Befolgen Sie den GitHub Flow Workflow. 
Bloggen und twittern (oder was auch immer) Sie regelmäßig über Ihre Beiträge! 
Hinweis: Sie werden vielleicht feststellen, dass einige der Themen derzeit nicht allen hier und auch auf dem Style Guide angegebenen Richtlinien entsprechen. Wir arbeiten daran, Konsistenz über den gesamten Standort zu erreichen. Überprüfen Sie die Liste der offenen Probleme, die wir derzeit für dieses spezifische Ziel verfolgen. 

Lizenzvereinbarung für Mitwirkende 
Sie müssen den. NET Foundation Contribution License Agreement (CLA) unterschreiben, bevor Ihre PR zusammengeführt wird. Dies ist eine einmalige Anforderung für Projekte in der . NET Foundation. Mehr über Contribution License Agreements (CLA) erfahren Sie auf Wikipedia. 

Die Vereinbarung: net-foundation-contribution-license-agreement. pdf 

Sie müssen die Vereinbarung nicht im Voraus unterschreiben. Sie können Ihren PR wie gewohnt klonen, verteilen und einreichen. Wenn Ihre PR erstellt wird, wird sie von einem CLA-Bot klassifiziert. Wenn die Änderung trivial ist (z. B. haben Sie einen Tippfehler behoben), dann wird die PR mit cla-not-required gekennzeichnet. Andernfalls wird es als cla-pflichtig eingestuft. Nachdem Sie den CLA unterzeichnet haben, werden die aktuellen und alle zukünftigen Pull-Requests als cla-signed gekennzeichnet.
1475 / 2048
Service provided by  DeepL
