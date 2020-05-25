using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace CustomElementClient
{
    class ConditionSnips
    {
        #region Conditions

        // <Snippet120>
        public void ConditionExamples(AutomationElement elementMainWindow)
        {
            if (elementMainWindow == null)
            {
                throw new ArgumentException();
            }

            // Use AndCondition to retrieve elements that match both of two conditions.

            Condition conditionEnabledButtons = new AndCondition(
                new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
            AutomationElementCollection enabledButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionEnabledButtons);
            Console.WriteLine("\nEnabled buttons:");
            foreach (AutomationElement autoElement in enabledButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use OrCondition to retrieve elements that match either of two conditions.

            Condition conditionButtons = new OrCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton));
            AutomationElementCollection elementCollectionButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionButtons);
            Console.WriteLine("\nButtons and radio buttons:");
            foreach (AutomationElement autoElement in elementCollectionButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use NotCondition to retrieve elements that do not match the previous condition.

            Condition conditionNotButtons = new NotCondition(conditionButtons);
            AutomationElementCollection elementCollectionNotButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionNotButtons);
            Console.WriteLine("\nOther control types:");
            foreach (AutomationElement autoElement in elementCollectionNotButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use the static TrueCondition to retrieve all elements.

            AutomationElementCollection elementCollectionAll = elementMainWindow.FindAll(
                TreeScope.Subtree, Condition.TrueCondition);
            Console.WriteLine("\nAll control types:");
            foreach (AutomationElement autoElement in elementCollectionAll)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use the static ContentViewCondition to retrieve all content elements.

            AutomationElementCollection elementCollectionContent = elementMainWindow.FindAll(
                TreeScope.Subtree, Automation.ContentViewCondition);
            Console.WriteLine("\nAll content elements:");
            foreach (AutomationElement autoElement in elementCollectionContent)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use the static ControlViewCondition to retrieve all control elements.

            AutomationElementCollection elementCollectionControl = elementMainWindow.FindAll(
                TreeScope.Subtree, Automation.ControlViewCondition);
            Console.WriteLine("\nAll control elements:");
            foreach (AutomationElement autoElement in elementCollectionControl)
            {
                Console.WriteLine(autoElement.Current.Name);
            }
        }
        // </Snippet120>

        // <Snippet178>
        /// <summary>
        /// Examples of using predefined conditions to find elements.
        /// </summary>
        /// <param name="elementMainWindow">The element for the target window.</param>
        public void StaticConditionExamples(AutomationElement elementMainWindow)
        {
            if (elementMainWindow == null)
            {
                throw new ArgumentException();
            }

            // Use TrueCondition to retrieve all elements.
            AutomationElementCollection elementCollectionAll = elementMainWindow.FindAll(
                TreeScope.Subtree, Condition.TrueCondition);
            Console.WriteLine("\nAll control types:");
            foreach (AutomationElement autoElement in elementCollectionAll)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use ContentViewCondition to retrieve all content elements.
            AutomationElementCollection elementCollectionContent = elementMainWindow.FindAll(
                TreeScope.Subtree, Automation.ContentViewCondition);
            Console.WriteLine("\nAll content elements:");
            foreach (AutomationElement autoElement in elementCollectionContent)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Use ControlViewCondition to retrieve all control elements.
            AutomationElementCollection elementCollectionControl = elementMainWindow.FindAll(
                TreeScope.Subtree, Automation.ControlViewCondition);
            Console.WriteLine("\nAll control elements:");
            foreach (AutomationElement autoElement in elementCollectionControl)
            {
                Console.WriteLine(autoElement.Current.Name);
            }
        }
        // </Snippet178>

        // <Snippet176>
        /// <summary>
        /// Uses AndCondition to retrieve elements that match both of two conditions.
        /// </summary>
        /// <param name="elementMainWindow">An application window element.</param>
        public void AndConditionExample(AutomationElement elementMainWindow)
        {
            if (elementMainWindow == null)
            {
                throw new ArgumentException();
            }

            AndCondition conditionEnabledButtons = new AndCondition(
                new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
            AutomationElementCollection enabledButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionEnabledButtons);
            Console.WriteLine("\nEnabled buttons:");
            foreach (AutomationElement autoElement in enabledButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Example of getting the conditions from the AndCondition.
            Condition[] conditions = conditionEnabledButtons.GetConditions();
            Console.WriteLine("AndCondition has " + conditions.GetLength(0) + " subconditions.");
        }
        // </Snippet176>

        // <Snippet175>
        /// <summary>
        /// Uses OrCondition to retrieve elements that match either of two conditions.
        /// </summary>
        /// <param name="elementMainWindow">An application window element.</param>
        public void OrConditionExample(AutomationElement elementMainWindow)
        {
            if (elementMainWindow == null)
            {
                throw new ArgumentException();
            }

            OrCondition conditionButtons = new OrCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton));
            AutomationElementCollection elementCollectionButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionButtons);
            Console.WriteLine("\nButtons and radio buttons:");
            foreach (AutomationElement autoElement in elementCollectionButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }

            // Example of getting the conditions from the OrCondition.
            Condition[] conditions = conditionButtons.GetConditions();
            Console.WriteLine("OrCondition has " + conditions.GetLength(0) + " subconditions.");
        }
        // </Snippet175>

        // <Snippet177>
        /// <summary>
        /// Uses NotCondition to retrieve elements that do not match specified conditions.
        /// </summary>
        /// <param name="elementMainWindow">An application window element.</param>
        public void NotConditionExample(AutomationElement elementMainWindow)
        {
            if (elementMainWindow == null)
            {
                throw new ArgumentException();
            }

            // Set up a condition that finds all buttons and radio buttons.
            OrCondition conditionButtons = new OrCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton));

            // Use NotCondition to retrieve elements that are not buttons or radio buttons.
            Condition conditionNotButtons = new NotCondition(conditionButtons);
            AutomationElementCollection elementCollectionNotButtons = elementMainWindow.FindAll(
                TreeScope.Subtree, conditionNotButtons);
            Console.WriteLine("Elements other than buttons:");
            foreach (AutomationElement autoElement in elementCollectionNotButtons)
            {
                Console.WriteLine(autoElement.Current.Name);
            }
        }
        // </Snippet177>

        public void GetTreeWalkerCondition()
        {
            NotCondition cond1 = (NotCondition)TreeWalker.ContentViewWalker.Condition;
        }

        #endregion Conditions

    }
}
