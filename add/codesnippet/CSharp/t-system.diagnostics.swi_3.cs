public class MyMethodTracingSwitch : Switch
{
     protected bool outExit;
     protected bool outEnter;
     protected MethodTracingSwitchLevel level;

     public MyMethodTracingSwitch(string displayName, string description) :
         base(displayName, description)
     {
     }

     public MethodTracingSwitchLevel Level
     {
         get
         {
             return level;
         }
         set
         {
             SetSwitchSetting((int)value);
         }
     }

     protected void SetSwitchSetting(int value)
     {
         if (value < 0)
         {
             value = 0;
         }
         if (value > 3)
         {
             value = 3;
         }

         level = (MethodTracingSwitchLevel)value;

         outEnter = false;
         if ((value == (int)MethodTracingSwitchLevel.EnteringMethod) ||
             (value == (int)MethodTracingSwitchLevel.Both))
         {
             outEnter = true;
         }

         outExit = false;
         if ((value == (int)MethodTracingSwitchLevel.ExitingMethod) ||
             (value == (int)MethodTracingSwitchLevel.Both))
         {
             outExit = true;
         }
     }

     public bool OutputExit
     {
         get
         {
             return outExit;
         }
     }

     public bool OutputEnter
     {
         get
         {
             return outEnter;
         }
     }
 }