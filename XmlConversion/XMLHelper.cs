using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlConversion
{
    public class XMLHelper
    {
        /// <summary>
        /// Serialize given object into XmlElement.
        /// </summary>
        /// <param name="transformObject">Input object for serialization.</param>
        /// <returns>Returns serialized XmlElement.</returns>
        #region Serialize given object into stream.
        public static XmlElement Serialize(object transformObject)
        {
            XmlElement serializedElement = null;
            try
            {
                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(transformObject.GetType());
                serializer.Serialize(memStream, transformObject);
                memStream.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                serializedElement = xmlDoc.DocumentElement;
            }
            catch (Exception SerializeException)
            {

            }
            return serializedElement;
        }
        #endregion // End - Serialize given object into stream.






        /// <summary>
        /// Deserialize given XmlElement into object.
        /// </summary>
        /// <param name="xmlElement">xmlElement to deserialize.</param>
        /// <param name="tp">Type of resultant deserialized object.</param>
        /// <returns>Returns deserialized object.</returns>
        #region Deserialize given string into object.
        public static object Deserialize(XmlElement xmlElement, System.Type tp)
        {
            Object transformedObject = null;
            try
            {
                Stream memStream = StringToStream(xmlElement.OuterXml);
                XmlSerializer serializer = new XmlSerializer(tp);
                transformedObject = serializer.Deserialize(memStream);
            }
            catch (Exception DeserializeException)
            {

            }
            return transformedObject;
        }
        #endregion // End - Deserialize given string into object.
        /// <summary>
        /// Conversion from string to stream.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Returns stream.</returns>
        #region Conversion from string to stream.
        public static Stream StringToStream(String str)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);//new byte[str.Length];
                memStream = new MemoryStream(buffer);
            }
            catch (Exception StringToStreamException)
            {
            }
            finally
            {
                memStream.Position = 0;
            }

            return memStream;
        }
        #endregion // End - Conversion from string to stream.
    }
}
