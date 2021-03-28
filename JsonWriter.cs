using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Talrand.Core
{
    public class JsonWriter
    {
        private MemoryStream memoryStream = new MemoryStream();
        private XmlDictionaryWriter writer = null;

        public JsonWriter()
        {
            writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream);
            writer.WriteStartDocument();
        }

        public void WriteStringElement(string name, string value)
        {
            writer.WriteElementString(name, value);
        }

        public void WriteNumberElement(string name, int value)
        {
            writer.WriteStartElement(name);
            WriteTypeAttribute("number");
            writer.WriteValue(value);
            writer.WriteEndElement();
        }

        public void WriteNumberElement(string name, decimal value)
        {
            writer.WriteStartElement(name);
            WriteTypeAttribute("number");
            writer.WriteValue(value);
            writer.WriteEndElement();
        }

        public void WriteBooleanElement(string name, bool value)
        {
            writer.WriteStartElement(name);
            WriteTypeAttribute("boolean");
            writer.WriteValue(value);
            writer.WriteEndElement();
        }

        public void WriteObjectStartElement(string name)
        {
            writer.WriteStartElement(name);
            WriteTypeAttribute("object");
        }

        public void WriteArrayStartElement(string name)
        {
            writer.WriteStartElement(name);
            WriteTypeAttribute("array");
        }

        public void WriteArrayItemStart()
        {
            WriteObjectStartElement("item");
        }

        private void WriteTypeAttribute(string value)
        {
            writer.WriteAttributeString("type", value);
        }

        public void WriteEndElement()
        {
            writer.WriteEndElement();
        }

        public void WriteToFile(string fileName)
        {
            File.WriteAllText(fileName, ToString());
        }

        public override string ToString()
        {
            CloseWriter();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        private void CloseWriter()
        {
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
    }
}