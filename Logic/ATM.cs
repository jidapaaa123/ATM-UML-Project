namespace Logic
{
	public class ATM // I am making some changes. Ill create aconstructor for ATM 
	{
		
		public bool cardInserted { get; set; } = false;
		public bool pinValidated { get; set; } = false;

		private BankServer bankServer;
		string currentCardNumber { get; set; } = "";
		// ATMAction currentAction { get; set; } = ATMAction.None;

		public ATM(BankServer bankServer)
        {
            this.bankServer = bankServer;
        }
        public void insertCard(string cardNumber) {
			cardInserted = true;
			currentCardNumber = cardNumber;
		}
		public bool enterPin() {
			Console.Write("Enter your pin: ");
			if (int.TryParse(Console.ReadLine(), out int pin)) {
				if (!bankServer.verifyPIN(currentCardNumber, pin)) {
					Console.WriteLine("Invalid pin. Please try again.");
				} else {
					pinValidated = true;
					return true;
				}
			}
			return false;
		}
		public void requestAmount() {
			Console.Write("Enter the amount you want to withdraw: ");
            if (!double.TryParse(Console.ReadLine(), out double amount)) {
                Console.WriteLine("Invalid amount. Please try again.");
                return;
            } else if (amount <= 0) {
                Console.WriteLine("Amount must be greater than 0. Please try again.");
                return;
            } else if (amount > bankServer.checkBalance(currentCardNumber)) {
                Console.WriteLine("Insufficient funds. Please try again.");
                return;
            } else {
                bankServer.processTransaction(currentCardNumber, amount);
                return;
            }
        }
		public void dispenseCash() {
			Console.WriteLine($"Please take your cash.");
		}
		public void checkBalance() {
			Console.WriteLine($"Current active balance for account {currentCardNumber}: {bankServer.checkBalance(currentCardNumber), -24}");
		}
		public void ejectCard() {
			cardInserted = false;
			currentCardNumber = "";
			pinValidated = false;
		}
        // ATMAction getNextAction() => currentAction != ATMAction.End ? currentAction++ : ATMAction.None;

        public enum ATMAction
        {
            InsertCard,
            EnterPIN,
            DisplayOptions
        }



        public ATMAction GetNextAction()
        {
            if (!cardInserted)
                return ATMAction.InsertCard;
            else if (!pinValidated)
                return ATMAction.EnterPIN;
            else
                return ATMAction.DisplayOptions;
        }
    }
}