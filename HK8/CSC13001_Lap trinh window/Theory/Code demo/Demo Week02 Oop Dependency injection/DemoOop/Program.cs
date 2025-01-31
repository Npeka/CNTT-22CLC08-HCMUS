using System.Globalization;
using System.Xml;

namespace DemoOop;

class Program
{     
    class Mobile {
       public string Name {get; set;}
       public int Price {get; set;} 
    }

    interface IRepository<T>
    {
        List<T> GetAll(); // Phân trang, Sort, Filter, Search
        //int DeleteById(int id);
        //int Update(T item);
        //int Insert(T item);
        //T GetById(int id);
    }

    abstract class IDao {
        public abstract IRepository<Mobile> Mobiles {get; set;}
    }
    class MockDao: IDao {
        public override IRepository<Mobile> Mobiles {get; set;} 
        public MockDao() {
            Mobiles = new MockMobileRepository();
        }

        private class MockMobileRepository: IRepository<Mobile> {
        public List<Mobile> GetAll() {
            return new List<Mobile>() {
                new Mobile() { Name = "iPhone 11 64GB", Price = 8950000},  
                new Mobile() { Name = "iPhone 12 128GB", Price = 12500000}, 
                new Mobile() { Name = "iPhone 13 Pro Max 256 GB", Price = 18990000}, 
                new Mobile() { Name = "iPhone 14 Pro 512GB", Price = 23790000},
            };
        }
    }    
    }

    class TextDao : IDao
    {
        public override IRepository<Mobile> Mobiles { get; set; }
        public TextDao(string path)
        {
            Mobiles = new TextMobileRepository(path);
        }

        private class TextMobileRepository : IRepository<Mobile>
        {
            private string _path;
            public TextMobileRepository(string path)
            {
                _path = path;
            }
            public List<Mobile> GetAll()
            {
                var result = new List<Mobile>();
                var lines = File.ReadAllLines(_path);
                //Name,Price
                for(int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    var mobile = new Mobile() { 
                        Name = parts[0], 
                        Price = int.Parse(parts[1]) 
                    };
                    result.Add(mobile);
                }

                return result; 
            }
        }
    }

    class XmlDao : IDao
    {
        public override IRepository<Mobile> Mobiles { get; set; }

        public XmlDao(string path)
        {
            Mobiles = new XmlMobileRepository(path);
        }

        private class XmlMobileRepository: IRepository<Mobile> {
            string _path = "";
            public XmlMobileRepository(string path)
            {
                _path = path;
            }

            public List<Mobile> GetAll()
            {
                var result = new List<Mobile>();

                XmlDocument document = new XmlDocument();
                document.Load(_path);

                XmlNodeList nodes = document.SelectNodes("/Phones/Phone");

                foreach(XmlNode node in nodes)
                {
                    string name = node.Attributes["Name"].Value;
                    int price = int.Parse(node.Attributes["Price"].Value);

                    var phone = new Mobile() { Name=name, Price = price };
                    result.Add(phone);
                }

                return result;
            }
        }
    }

    class MobileToLineConverter {
        public string Convert(Mobile info)
        {
           var numberConverter = new IntegerToFormattedConverter();

            return $"{info.Name} - {numberConverter.Convert(info.Price)}";
        }
    }

    class IntegerToFormattedConverter
    {
        public string Convert(int value)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("vi-VN");  // en-US /en-UK
            return string.Format(culture , "{0:c}", value);
        }
    }

    class MobilesToTableConverter
    {
        public string Convert(List<Mobile> items)
        {
            string result = "";

            // Thuật toán xác định độ rộng của cột dựa trên các items
            List<int> columns = new List<int>();

            result += "|Name                     |Price         |\n";
            result += "----------------------------------------------\n";

            foreach (var item in items)
            {
                var rowConverter = new MobileToRowConverter();
                result += $"|{rowConverter.Convert(item)}|\n";
            }

            return result;
        }

        /*inner*/ class MobileToRowConverter
        {
            public string Convert(Mobile info)
            {
                var numberConverter = new IntegerToFormattedConverter();
                return $"{info.Name.PadRight(25)}|{numberConverter.Convert(info.Price).PadRight(14)}";
            }
        }
    }

    // ServicesRegistry / ServicesLocator
    class Services // Dependencies injection Extension
    {
        public static Dictionary<string, object> _services = new ();
        public static void AddSingleton<Parent>(object service)
        {
            string name = typeof(Parent).Name;
            _services[name] = service;
        }

        public static T GetSingleton<T>()
        {
            string name = typeof(T).Name;
            return (T)_services[name];
        }
    }

    static void Main()
    {
        Config();
        UseCase_DisplayAllMobiles();
    }

    private static void Config()
    {
        //Services.AddSingleton<IDao>(new MockDao());
        //Services.AddSingleton<IDao>(new TextDao("phones.txt"));
        Services.AddSingleton<IDao>(new XmlDao("phones.xml"));
    }

    private static void UseCase_DisplayAllMobiles()
    {
        IDao dao = Services.GetSingleton<IDao>();
        List<Mobile> mobiles = dao.Mobiles.GetAll();

        // 1. Dạng danh sách thông thường
        Console.WriteLine($"Crawled {mobiles.Count} phones from mobiles.com/iphone");
        var phoneConverter = new MobileToLineConverter();
        foreach (var phone in mobiles)
        {
            Console.WriteLine(phoneConverter.Convert(phone));
        }
        Console.WriteLine();

        // 2.Dạng bảng
        Console.WriteLine($"Crawled {mobiles.Count} phones from mobiles.com/iphone");
        var tableConverter = new MobilesToTableConverter();
        Console.WriteLine(tableConverter.Convert(mobiles));
    }
}
