using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Talrand.Core
{
    public class JsonWriter : IDisposable
    {
        private readonly MemoryStream _memoryStream = new MemoryStream();
        private readonly XmlDictionaryWriter _writer = null;
        private bool _isDisposed;

        public JsonWriter()
        {
            _writer = JsonReaderWriterFactory.CreateJsonWriter(_memoryStream);
            _writer.WriteStartDocument();
        }

        public void WriteStringElement(string name, string value)
        {
            _writer.WriteElementString(name, value);
        }

        public void WriteNumberElement(string name, int value)
        {
            _writer.WriteStartElement(name);
            WriteTypeAttribute("number");
            _writer.WriteValue(value);
            _writer.WriteEndElement();
        }

        public void WriteNumberElement(string name, decimal value)
        {
            _writer.WriteStartElement(name);
            WriteTypeAttribute("number");
            _writer.WriteValue(value);
            _writer.WriteEndElement();
        }

        public void WriteBooleanElement(string name, bool value)
        {
            _writer.WriteStartElement(name);
            WriteTypeAttribute("boolean");
            _writer.WriteValue(value);
            _writer.WriteEndElement();
        }

        public void WriteObjectStartElement(string name)
        {
            _writer.WriteStartElement(name);
            WriteTypeAttribute("object");
        }

        public void WriteArrayStartElement(string name)
        {
            _writer.WriteStartElement(name);
            WriteTypeAttribute("array");
        }

        public void WriteArrayItemStart()
        {
            WriteObjectStartElement("item");
        }

        private void WriteTypeAttribute(string value)
        {
            _writer.WriteAttributeString("type", value);
        }

        public void WriteEndElement()
        {
            _writer.WriteEndElement();
        }

        public void WriteToFile(string fileName)
        {
            File.WriteAllText(fileName, ToString());
        }

        public override string ToString()
        {
            CloseWriter();
            return Encoding.UTF8.GetString(_memoryStream.ToArray());
        }

        private void CloseWriter()
        {
            _writer.WriteEndDocument();
            _writer.Flush();
            _writer.Close();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing == true)
                {
                    // Dispose managed objects
                    _writer.Dispose();
                    _memoryStream.Dispose();
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}