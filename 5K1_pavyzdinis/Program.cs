//Aistis Jakutonis IFF 3/1

using System.Globalization;
using System.Text;

namespace K1_pavyzdinis
{
    public class Book
    {
        public string platintojas { get; }
        public string pavadinimas { get; }
        public int kiekis { get; set; }
        public decimal kaina { get; set; }

        public Book(string platintojas, string pavadinimas, int kiekis, decimal kaina)
        {
            this.platintojas = platintojas;
            this.pavadinimas = pavadinimas;
            this.kiekis = kiekis;
            this.kaina = kaina;
        }

        public Book(string pavadinimas)
        {
            this.platintojas = "";
            this.pavadinimas = pavadinimas;
            this.kiekis = 1;
            this.kaina = 0;
        }

        public static bool operator <=(Book left, Book right)
        {
            return false;
        }

        public static bool operator >=(Book left, Book right)
        {
            if (left.pavadinimas != right.pavadinimas)
            {
                return false;
            }
            if (left.kiekis <= 0)
            {
                return false;
            }
            return left.kaina >= right.kaina;
        }

        public override string ToString()
        {
            string line;

            line = String.Format("| {0,-11} | {1,-20} | {2,6} | {3,5} €|", this.platintojas, this.pavadinimas, this.kiekis, this.kaina);

            return line;
        }
    }

    public class BookStore
    {
        private List<Book> AllBooks;

        public BookStore()
        {
            AllBooks = new List<Book>();
        }

        public BookStore(List<Book> books)
        {
            AllBooks = new List<Book>();

            foreach (Book book in books)
            {
                this.AllBooks.Add(book);
            }
        }

        public int GetCount()
        {
            return this.AllBooks.Count();
        }

        public Book GetBook(int index)
        {
            return this.AllBooks[index];
        }

        public void AddBook(Book book)
        {
            AllBooks.Add(book);
        }

        public decimal Sum()
        {
            decimal suma = 0;

            foreach (Book book in this.AllBooks)
            {
                suma += book.kiekis * book.kaina;
            }

            return suma;
        }

        public int IndexMaxPrice(Book book)
        {
            int didziausia = -1;

            for (int i = 0; i < GetCount(); i++)
            {
                if (AllBooks[i] >= book)
                {
                    didziausia = i;
                }
            }

            return didziausia;
        }

        public void AddSalePrice(List<Book> books)
        {
            foreach (Book sold in books)
            {
                int best = this.IndexMaxPrice(sold);
                if (best >= 0)
                {
                    Book bestBook = this.GetBook(best);
                    sold.kaina = bestBook.kaina;
                    bestBook.kiekis--;
                }
            }
        }
    }

    public class InOut
    {
        public static BookStore InputBooks(string fileName)
        {
            BookStore bookStore = new BookStore();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] values = line.Split(";");
                string platintojas = values[0];
                string pavadinimas = values[1];
                int kiekis = int.Parse(values[2]);
                decimal kaina = decimal.Parse(values[3], new CultureInfo("lt-Lt"));

                Book book = new Book(platintojas, pavadinimas, kiekis, kaina);

                bookStore.AddBook(book);
            }

            return bookStore;
        }

        public static List<Book> InputSoldBooks(string fileName)
        {
            List<Book> books = new List<Book>();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string pavadinimas = line;

                Book book = new Book(pavadinimas);

                books.Add(book);
            }

            return books;
        }

        public static void Print(BookStore books, string fileName, string header)
        {
            List<string> lines = new List<string>();

            lines.Add(String.Format("{0}", header));
            lines.Add(new string('-', 56));
            lines.Add(String.Format("| {0,-11} | {1,-20} | {2,6} | {3,5}  |", "Platintojas", "Pavadinimas", "Kiekis", "Kaina"));
            lines.Add(new string('-', 56));

            for (int i = 0; i < books.GetCount(); i++)
            {
                Book book = books.GetBook(i);

                lines.Add(book.ToString());
            }

            lines.Add(new string('-', 56));
            lines.Add("");

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        public static void Print(List<Book> books, string fileName, string header)
        {
            List<string> lines = new List<string>();

            lines.Add(String.Format("{0}", header));
            lines.Add(new string('-', 33));
            lines.Add(String.Format("| {0,-20} | {1,5}  |", "Pavadinimas", "Kaina"));
            lines.Add(new string('-', 33));

            for (int i = 0; i < books.Count(); i++)
            {
                Book book = books[i];

                lines.Add(String.Format("| {0,-20} | {1,5} €|", book.pavadinimas, book.kaina));
            }

            lines.Add(new string('-', 33));
            lines.Add("");

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
    }

    class Program
    {
        const string RezFile = "Rez.txt";

        static void Main(string[] args)
        {
            File.Delete(RezFile);

            BookStore store = InOut.InputBooks(@"../../../Knygos.txt");

            List<Book> sold = InOut.InputSoldBooks(@"../../../Parduota.txt");

            InOut.Print(store, RezFile, "Pradine knygyno lentele");
            InOut.Print(sold, RezFile, "Pradine knygu pardavimo lentele");

            store.AddSalePrice(sold);
            InOut.Print(sold, RezFile, "Papildyta knygu pardavimo lentele");
            InOut.Print(store, RezFile, "Pakeista knygyno lentele");

            decimal sum = store.Sum();
            File.AppendAllText(RezFile, $"Turi dar surinkti {sum:f2} €");
        }
    }

}
