using System;
namespace ReceiveMessages
{

    public class Header
	{
		public TransactionTypeEnum TransactionType { get; set; }
		public ElementEnum Element { get; set; }
		public bool Multiple { get; set; }
	}
}

