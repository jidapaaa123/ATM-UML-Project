namespace Logic
{
	class ATM(BankServer bankServer)
	{
		public bool cardInserted { get; set; } = false;
		public bool pinValidated { get; set; } = false;
		BankServer bankServer { get; set; } = bankServer;
		string currentCardNumber { get; set; } = "";
		ATMAction currentAction { get; set; } = ATMAction.None;
		public void insertCard(string cardNumber) {
			cardInserted = true;
			currentCardNumber = cardNumber;
		}
		public bool enterPin(int pin) {
			Console.Write("Enter your pin: ");
			if (!bankServer.verifyPin(Console.ReadLine())) {
				Console.WriteLine("Invalid pin. Please try again.");
				return false;
			} else {
				pinValidated = true;
				return true;
			}
		}
		public bool requestAmount() {
			Console.Write("Enter the amount you want to withdraw: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount)) {
                Console.WriteLine("Invalid amount. Please try again.");
                return false;
            } else if (amount <= 0) {
                Console.WriteLine("Amount must be greater than 0. Please try again.");
                return false;
            } else if (amount > bankServer.checkBalance(currentCardNumber)) {
                Console.WriteLine("Insufficient funds. Please try again.");
                return false;
            } else {
                bankServer.processTransaction(currentCardNumber, amount);
                return true;
            }
        }
		public void dispenseCash() {
			Console.WriteLine($"Please take your cash.");
		}
		public void checkBalance() {
			Console.WriteLine($"Current active balance for account {0:30}: {1:24}", currentCardNumber, bankServer.checkBalance(currentCardNumber));
		}
		public void ejectCard() {
			cardInserted = false;
			currentCardNumber = "";
			pinValidated = false;
		}
		ATMAction getNextAction() => currentAction != ATMAction.End ? currentAction++ : ATMAction.None;
	}
}