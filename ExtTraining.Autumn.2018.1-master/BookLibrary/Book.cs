using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book:IFormattable
    {
        public string Title
        {set; get; }
        public string Author
        { set; get; }
        public string Year
        { set; get; }
        public string PublishingHouse
        { set; get; }
        public string Edidion
        { set; get; }
        public string Pages
        { set; get; }
        public string Price
        { set; get; }
        public Book(string title, string author, string year, string publishingHouse, string edition, string pages, string price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHouse = publishingHouse;
            Edidion = edition;
            Pages = pages;
            Price = price;
        }

        public string ToString(string format, IFormatProvider formatProvider=null)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException();
            }
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.InvariantCulture;
            }
            StringBuilder result = new StringBuilder("Book record: ");
            for (int i = 0; i < format.Length; i++)
            {
                switch (format[i])
                {
                    case'T':
                        {
                            result.Append(Title);
                            break;
                        }
                    case 'A':
                        {
                            result.Append(Author);
                            break;
                        }
                    case 'Y':
                        {
                            result.Append(Year);
                            break;
                        }
                    case 'H':
                        {
                            result.Append(PublishingHouse);
                            break;
                        }
                    case 'E':
                        {
                            result.Append(Edidion);
                            break;
                        }
                    case 'G':
                        {
                            result.Append(Pages);
                            break;
                        }
                    case 'P':
                        {
                            result.Append(Price);
                            break;
                        }
                    default:
                        throw new FormatException();
                }
                if (i != format.Length - 1)
                { result.Append(", "); }
            }
            return result.ToString();
        }
    }
}
