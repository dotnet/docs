using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Reflection;
using System.Windows.Automation;
using System.Diagnostics;

namespace GetSupportedPatterns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            ListPatterns();
        }

        private void btnProps_Click(object sender, EventArgs e)
        {
            ListRequiredProperties();
        }

        /// <summary>
        /// Outputs the patterns supported, and never supported, by all control types.
        /// Control types are obtained through reflection.
        /// </summary>
        private void oldListPatterns()
        {
            AutomationPattern[] patternsNeverSupported;
            AutomationPattern[][] patternsSupported;

            ControlType controlTypeInstance = ControlType.Button;  // Any instance will do.
            Type type = typeof(ControlType);
            System.Reflection.FieldInfo[] arrayInfo = type.GetFields();
            foreach (System.Reflection.FieldInfo info in arrayInfo)
            {
                if (info.IsStatic)
                {
                    ControlType controlType = info.GetValue(controlTypeInstance) as ControlType;
                    Debug.WriteLine("\n********************");
                    Debug.WriteLine(controlType.ProgrammaticName);
                    Debug.WriteLine("Never supports:");
                    patternsNeverSupported = controlType.GetNeverSupportedPatterns();
                    if (patternsNeverSupported.GetLength(0) == 0)
                    {
                        Debug.WriteLine("(None)");
                    }
                    else foreach (AutomationPattern pattern in patternsNeverSupported)
                        {
                            Debug.WriteLine(pattern.ProgrammaticName);
                        }
                    Debug.WriteLine("\nRequires one of the following sets:");
                    patternsSupported = controlType.GetRequiredPatternSets();
                    if (patternsSupported.GetLength(0) == 0)
                    {
                        Debug.WriteLine("(None)");
                    }
                    else foreach (AutomationPattern[] patternSet in patternsSupported)
                        {
                            Debug.WriteLine("Pattern set:");
                            foreach (AutomationPattern requiredPattern in patternSet)
                            {
                                Debug.WriteLine(requiredPattern.ProgrammaticName);
                            }
                            Debug.WriteLine("--------------------");
                        }
                }
            }
        }

        // <Snippet101>
        /// <summary>
        /// Obtains information about patterns supported by control types.
        /// Control types are obtained by reflection.
        /// </summary>
        private void ListPatterns()
        {
            // Any instance of a ControlType will do since we just want to get the type.
            ControlType controlTypeInstance = ControlType.Button;
            Type type = typeof(ControlType);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.IsStatic)
                {
                    ControlType controlType = field.GetValue(controlTypeInstance) as ControlType;
                    Console.WriteLine("\n******************** {0} never supports:",
                                       controlType.ProgrammaticName);
                    AutomationPattern[] neverSupportedPatterns =
                                       controlType.GetNeverSupportedPatterns();
                    if (neverSupportedPatterns.Length == 0)
                    {
                        Console.WriteLine("(None)");
                    }
                    else
                    {
                        foreach (AutomationPattern pattern in neverSupportedPatterns)
                        {
                            Console.WriteLine(pattern.ProgrammaticName);
                        }
                    }

                    Console.WriteLine("\n******************** {0} requires:",
                                      controlType.ProgrammaticName);
                    AutomationPattern[][] requiredPatternSets =
                                      controlType.GetRequiredPatternSets();
                    if (requiredPatternSets.Length == 0)
                    {
                        Console.WriteLine("(None)");
                    }
                    else
                    {
                        foreach (AutomationPattern[] patterns in requiredPatternSets)
                        {
                            Console.WriteLine("Pattern set:");
                            foreach (AutomationPattern pattern in patterns)
                            {
                                Console.WriteLine(pattern.ProgrammaticName);
                            }
                            Console.WriteLine("--------------------");
                        }
                    }
                }
            }
        }
        // </Snippet101>

 // NOTHING GETS RETURNED FROM THE FOLLOWING       
        // <Snippet102>
        private void ListRequiredProperties()
        {
            AutomationProperty[] propertiesRequired;
                                
            // Get any ControlType instance.
            ControlType controlTypeInstance = ControlType.Button;
            Type type = typeof(ControlType);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.IsStatic)
                {
                    ControlType controlType = field.GetValue(controlTypeInstance) as ControlType;
                    Debug.WriteLine("\n********************");
                    Debug.WriteLine(controlType.ProgrammaticName);
                    Debug.WriteLine("Required properties:");
                    propertiesRequired = controlType.GetRequiredProperties();
                    if (propertiesRequired.GetLength(0) == 0)
                    {
                        Debug.WriteLine("(None)");
                    }
                    else foreach (AutomationProperty prop in propertiesRequired)
                    {
                        Debug.WriteLine(prop.ProgrammaticName);
                    }
                }
            }
// </Snippet102>
        }

    }









}