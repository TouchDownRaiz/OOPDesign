using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command {
    //Build simple bank account
    public class BankAccount {
        int balanse;
        int ovedraftLimit = -500;

        public void Deposit(int amount) {
            balanse += amount;
            Console.WriteLine($"Deposite ${amount}, balance = {balanse}");
        }

        public void Withdraw(int amount) {
            if (balanse - amount >= ovedraftLimit) {
                balanse -= amount;
                Console.WriteLine($"Withdraw ${amount}, balance = {balanse}");
            }
        }

        public override string ToString() {
            return $"{nameof(balanse)}: {balanse}";
        }
    }

    //class Command
    public class BankAccountCommand {
        BankAccount acount;

        public enum Action {
            Deposit, Withdraw
        }
        Action action;
        int amount;

        public BankAccountCommand(BankAccount account, Action action, int amount) {
            this.acount = account;
            this.action = action;
            this.amount = amount;

        }

        // Command call self
        public void Call() {
            switch(action) {
                case Action.Deposit:
                    acount.Deposit(amount);
                    break;
                case Action.Withdraw:
                    acount.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

    }

    class Program {
        static void Main(string[] args) {
            var bancAc = new BankAccount();
            var cmd = new BankAccountCommand(bancAc, BankAccountCommand.Action.Deposit, 100);
            cmd.Call();
            Console.WriteLine(bancAc.ToString());
            Console.ReadLine();

            // Есть вариации - Вызов команд происходит внутри команды,
            // вызов происходит внутри класса банкаккаунт (в том объекте на который команда работает )
            // и вызов происходит каким то сторонним обработчиком команд (отдельный класс получает команду)

        }
    }
}
