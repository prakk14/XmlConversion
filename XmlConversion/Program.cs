using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Data;

namespace XmlConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlListConversion();

            //DataSetXmlConversion();

            //DataTableXmlConversion();

            Console.ReadLine();
        }

        /// <summary>
        /// DataTable Xml Conversion
        /// </summary>
        private static void DataTableXmlConversion()
        {
            DataTable objDt = new DataTable();
            objDt.TableName = "Employee";
            objDt.Columns.Add("ID");
            objDt.Columns.Add("FName");
            objDt.Columns.Add("LName");
            objDt.Columns.Add("DOB");
            objDt.Columns.Add("Sex");

            objDt.Rows.Add(new object[] { "1", "John", "Shields", DateTime.Parse("12/11/1971"), 'M' });
            objDt.Rows.Add(new object[] { "2", "Mary", "Jacobs", DateTime.Parse("01/17/1961"), 'F' });
            objDt.Rows.Add(new object[] { "3", "Amber", "Agar", DateTime.Parse("12/23/1971"), 'M' });
            objDt.Rows.Add(new object[] { "4", "Kathy", "Berry", DateTime.Parse("11/15/1976"), 'F' });
            objDt.Rows.Add(new object[] { "5", "Lena", "Bilton", DateTime.Parse("05/11/1978"), 'F' });
            objDt.Rows.Add(new object[] { "6", "Susanne", "Buck", DateTime.Parse("03/7/1965"), 'F' });
            objDt.Rows.Add(new object[] { "7", "Jim", "Brown", DateTime.Parse("09/11/1972"), 'M' });
            objDt.Rows.Add(new object[] { "8", "Jane", "Hooks", DateTime.Parse("12/11/1972"), 'F' });
            objDt.Rows.Add(new object[] { "9", "Robert", "", DateTime.Parse("06/28/1964"), 'M' });
            objDt.Rows.Add(new object[] { "10", "Cindy", "Fox", DateTime.Parse("01/11/1978"), 'M' });

            /* 
            * Serialize DataTable To Xml
            */
            Console.WriteLine("Serialize List To Xml\n");
            XmlElement xmlFrList = (XmlElement)XMLHelper.Serialize(objDt);
            string strXml = xmlFrList.OuterXml.ToString();
            Console.WriteLine(strXml);
            Console.WriteLine("====================================Serialize DataTable To Xml END===================\n");

            /* 
             * Deserialize XmlToDataTable
             */
            Console.WriteLine("Deserialize Xml To DataTable\n");
            DataTable objDtFrXml = (DataTable)XMLHelper.Deserialize(xmlFrList, typeof(DataTable));


            foreach (DataRow emp in objDtFrXml.Rows)
            {
                Console.WriteLine("ID:" + Utils.ToInteger(emp["ID"]));
                Console.WriteLine("FName:" + Utils.ToString(emp["FName"]));
                Console.WriteLine("LName:" + Utils.ToString(emp["LName"]));
                Console.WriteLine("DOB:" + Utils.ToString(emp["DOB"]));
                Console.WriteLine("Sex:" + Utils.ToString(emp["Sex"]));
                Console.WriteLine("\n");
            }
            Console.WriteLine("====================================Deserialize Xml To DataTable END===================\n");
        }

        /// <summary>
        /// DataSet Xml Conversion
        /// </summary>
        private static void DataSetXmlConversion()
        {
            DataSet objDS = new DataSet();

            DataTable objDt = new DataTable();
            objDt.TableName = "Employee";
            objDt.Columns.Add("ID");
            objDt.Columns.Add("FName");
            objDt.Columns.Add("LName");
            objDt.Columns.Add("DOB");
            objDt.Columns.Add("Sex");

            objDt.Rows.Add(new object[] { "1", "John", "Shields", DateTime.Parse("12/11/1971"), 'M' });
            objDt.Rows.Add(new object[] { "2", "Mary", "Jacobs", DateTime.Parse("01/17/1961"), 'F' });
            objDt.Rows.Add(new object[] { "3", "Amber", "Agar", DateTime.Parse("12/23/1971"), 'M' });
            objDt.Rows.Add(new object[] { "4", "Kathy", "Berry", DateTime.Parse("11/15/1976"), 'F' });
            objDt.Rows.Add(new object[] { "5", "Lena", "Bilton", DateTime.Parse("05/11/1978"), 'F' });
            objDt.Rows.Add(new object[] { "6", "Susanne", "Buck", DateTime.Parse("03/7/1965"), 'F' });
            objDt.Rows.Add(new object[] { "7", "Jim", "Brown", DateTime.Parse("09/11/1972"), 'M' });
            objDt.Rows.Add(new object[] { "8", "Jane", "Hooks", DateTime.Parse("12/11/1972"), 'F' });
            objDt.Rows.Add(new object[] { "9", "Robert", "", DateTime.Parse("06/28/1964"), 'M' });
            objDt.Rows.Add(new object[] { "10", "Cindy", "Fox", DateTime.Parse("01/11/1978"), 'M' });

            objDS.Tables.Add(objDt);


            /* 
            * Serialize DataSet To Xml
            */
            Console.WriteLine("Serialize List To Xml\n");
            XmlElement xmlFrList = (XmlElement)XMLHelper.Serialize(objDS);
            string strXml = xmlFrList.OuterXml.ToString();
            Console.WriteLine(strXml);
            Console.WriteLine("====================================Serialize DataSet To Xml END===================\n");

            /* 
             * Deserialize XmlToDataSet
             */
            Console.WriteLine("Deserialize Xml To DataSet\n");
            DataSet objDSFrXml = (DataSet)XMLHelper.Deserialize(xmlFrList, typeof(DataSet));


            foreach (DataRow emp in objDSFrXml.Tables[0].Rows)
            {
                Console.WriteLine("ID:" + Utils.ToInteger(emp["ID"]));
                Console.WriteLine("FName:" + Utils.ToString(emp["FName"]));
                Console.WriteLine("LName:" + Utils.ToString(emp["LName"]));
                Console.WriteLine("DOB:" + Utils.ToString(emp["DOB"]));
                Console.WriteLine("Sex:" + Utils.ToString(emp["Sex"]));
                Console.WriteLine("\n");
            }
            Console.WriteLine("====================================Deserialize Xml To DataSet END===================\n");
        }

        /// <summary>
        /// Xml List Conversion
        /// </summary>
        private static void XmlListConversion()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, FName = "John", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 2, FName = "Mary", LName = "Jacobs", DOB = DateTime.Parse("01/17/1961"), Sex = 'F' });
            empList.Add(new Employee() { ID = 3, FName = "Amber", LName = "Agar", DOB = DateTime.Parse("12/23/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 4, FName = "Kathy", LName = "Berry", DOB = DateTime.Parse("11/15/1976"), Sex = 'F' });
            empList.Add(new Employee() { ID = 5, FName = "Lena", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
            empList.Add(new Employee() { ID = 6, FName = "Susanne", LName = "Buck", DOB = DateTime.Parse("03/7/1965"), Sex = 'F' });
            empList.Add(new Employee() { ID = 7, FName = "Jim", LName = "Brown", DOB = DateTime.Parse("09/11/1972"), Sex = 'M' });
            empList.Add(new Employee() { ID = 8, FName = "Jane", LName = "Hooks", DOB = DateTime.Parse("12/11/1972"), Sex = 'F' });
            empList.Add(new Employee() { ID = 9, FName = "Robert", LName = "", DOB = DateTime.Parse("06/28/1964"), Sex = 'M' });
            empList.Add(new Employee() { ID = 10, FName = "Cindy", LName = "Fox", DOB = DateTime.Parse("01/11/1978"), Sex = 'M' });

            /* 
             * Serialize ListToXml
             */
            Console.WriteLine("Serialize List To Xml\n");
            XmlElement xmlFrList = (XmlElement)XMLHelper.Serialize(empList);
            string strXml = xmlFrList.OuterXml.ToString();
            Console.WriteLine(strXml);
            Console.WriteLine("====================================List To Xml END===================\n");

            /* 
             * Deserialize XmlToList
             */
            Console.WriteLine("Deserialize Xml To List\n");
            List<Employee> objListFrXml = (List<Employee>)XMLHelper.Deserialize(xmlFrList, typeof(List<Employee>));

            foreach (var emp in objListFrXml)
            {
                Console.WriteLine("ID:" + emp.ID);
                Console.WriteLine("FName:" + emp.FName);
                Console.WriteLine("LName:" + emp.LName);
                Console.WriteLine("DOB:" + emp.DOB);
                Console.WriteLine("Sex:" + emp.Sex);
                Console.WriteLine("\n");
            }

            Console.WriteLine("====================================Xml To List END===================\n");
        }
    }
}
