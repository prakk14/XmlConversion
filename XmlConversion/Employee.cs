using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlConversion
{
    public class Employee
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }

        [XmlIgnore]
        public char Sex { get; set; }

        [XmlElement("Sex"), Browsable(false)]
        public string SexString
        {
            get { return Sex.ToString(); }
            set { Sex = value.Single(); }
        }
    }
}
