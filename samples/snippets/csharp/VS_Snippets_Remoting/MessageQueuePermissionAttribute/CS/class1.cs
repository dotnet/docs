// <snippet0>

using System;
using System.Messaging;

public class MessageQueuePermissionAttributeExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        MessageQueuePermissionAttributeExample example =
            new MessageQueuePermissionAttributeExample();

        // Create a non-transactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate the members of MessageQueuePermissionAttribute.
        // Note that the Path, FormatName, MachineName, Label, and Category
        // property values cannot all be set on the same instance of
        // MessageQueuePermissionAttribute. Trying to do so will throw an
        // exception of type System.InvalidOperationException.
        example.CreateAttribute();
        example.CategoryExample();
        example.LabelExample();
        example.MachineNameExample();
        example.PathExample();
        example.PermissionAccessExample();
        example.CreatePermissionExample();
    }

    // Creates a new queue.
    public static void CreateQueue(string queuePath, bool transactional)
    {
        if(!MessageQueue.Exists(queuePath))
        {
            MessageQueue.Create(queuePath, transactional);
        }
        else
        {
            Console.WriteLine(queuePath + " already exists.");
        }
    }

    // Demonstrates the following MessageQueuePermissionAttribute constructor:
    // public #ctor (SecurityAction action)
    public void CreateAttribute()
    {
        // <snippet1>

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // </snippet1>
    }

    public void CategoryExample()
    {
        // <snippet2>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Category property value, based on the queue's
        // Category property value.
        attribute.Category = queue.Category.ToString();

        // Display the new value of the attribute's Category property.
        Console.WriteLine("attribute.Category: {0}",
            attribute.Category.ToString());

        // </snippet2>
    }

    public void LabelExample()
    {
        // <snippet3>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Label property value, based on the queue's Label
        // property value.
        attribute.Label = queue.Label;

        // Display the new value of the attribute's Label property.
        Console.WriteLine("attribute.Label: {0}", attribute.Label);

        // </snippet3>
    }

    public void MachineNameExample()
    {
        // <snippet4>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's MachineName property value, based on the queue's
        // MachineName property value.
        attribute.MachineName = queue.MachineName;

        // Display the new value of the attribute's MachineName property.
        Console.WriteLine("attribute.MachineName: {0}",
            attribute.MachineName);

        // </snippet4>
    }

    public void PathExample()
    {
        // <snippet5>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Path property value, based on the queue's Path
        // property value.
        attribute.Path = queue.Path;

        // Display the new value of the attribute's Path property.
        Console.WriteLine("attribute.Path: {0}", attribute.Path);

        // </snippet5>
    }

    public void PermissionAccessExample()
    {
        // <snippet6>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's PermissionAccess property value.
        attribute.PermissionAccess = MessageQueuePermissionAccess.Receive;

        // Display the new value of the attribute's PermissionAccess property.
        Console.WriteLine("attribute.PermissionAccess: {0}",
            attribute.PermissionAccess);

        // </snippet6>
    }

    public void CreatePermissionExample()
    {
        // <snippet7>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionAttribute.
        MessageQueuePermissionAttribute attribute =
            new MessageQueuePermissionAttribute(
            System.Security.Permissions.SecurityAction.Assert);

        // Set the attribute's Path property value, based on the queue's Path
        // property value.
        attribute.Path = queue.Path;

        // Get an IPermission interface by calling the attribute's
        // CreatePermission() method.
        System.Security.IPermission permission = attribute.CreatePermission();

        // </snippet7>
    }
}

// </snippet0>