using System;
using System.ServiceModel;

namespace Microsoft.WCF.Documentation
{
    interface IOperationCache
    {
        void Insert(OperationCacheKey key, OperationCacheValue value);
        OperationCacheValue Lookup(OperationCacheKey key);
        void Remove(OperationCacheKey key);
    }

	class OperationCacheKey
	{
		string action;
		object[] inputs;

		public OperationCacheKey(string action, object[] inputs)
		{
			this.action = action;
			this.inputs = inputs;
		}

		public string Action
		{
			get { return action; }
		}

		public object[] Inputs
		{
			get { return inputs; }
		}

		public override bool Equals(object obj)
		{
			OperationCacheKey key = obj as OperationCacheKey;
			if (key == null)
				return false;

			if (this.action != key.action)
				return false;

			if (this.inputs.Length != key.inputs.Length)
				return false;

			for (int i = 0; i < this.inputs.Length; i++)
			{
				if (!this.inputs[i].Equals(key.inputs[i]))
					return false;
			}

			return true;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;

			hashCode = (hashCode + action.GetHashCode()) % int.MaxValue;

			foreach (object input in inputs)
			{
				hashCode = (hashCode + input.GetHashCode()) % int.MaxValue;
			}

			return hashCode;
		}
	}

	class OperationCacheValue
	{
		object returnValue;
		object[] outputs;

		public OperationCacheValue(object[] outputs, object returnValue)
		{
			this.outputs = outputs;
			this.returnValue = returnValue;
		}

		public object[] Outputs
		{
			get
			{
				return outputs;
			}
		}

		public object ReturnValue
		{
			get
			{
				return returnValue;
			}
		}
	}
}
