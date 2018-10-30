using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parent;

        public BookFormatExtension()
            : this(CultureInfo.CurrentCulture)
        {
        }

        public BookFormatExtension(IFormatProvider parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException($"{nameof(parent)} can not be null.");
            }

            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider = null)
        {
            Book book = (Book)arg;
            StringBuilder result = new StringBuilder("Book record: ");
            for (int i = 0; i < format.Length; i++)
            {
                switch (format[i])
                {
                    case 'T':
                    {
                        result.Append(book.Title);
                        break;
                    }
                    case 'A':
                    {
                        result.Append(book.Author);
                        break;
                    }
                    case 'Y':
                    {
                        result.Append(book.Year);
                        break;
                    }
                    case 'H':
                    {
                        result.Append(book.PublishingHouse);
                        break;
                    }
                    case 'E':
                    {
                        result.Append(book.Edidion);
                        break;
                    }
                    case 'G':
                    {
                        result.Append(book.Pages);
                        break;
                    }
                    case 'P':
                    {
                        result.Append(string.Format("{0:C}", Convert.ToDouble(book.Price)));
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
