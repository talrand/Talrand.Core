using System;
using System.IO;
using System.Text;

namespace Talrand.Core
{
    public class XmlWriter : IDisposable
    {
        private readonly MemoryStream _memoryStream = new MemoryStream();
        private readonly System.Xml.XmlWriter _writer = null;
        private bool _isDisposed;

        public XmlWriter()
        {
            _writer = System.Xml.XmlWriter.Create(_memoryStream, new System.Xml.XmlWriterSettings() { 
                        Indent = true, Encoding = new UTF8Encoding(false), ConformanceLevel = System.Xml.ConformanceLevel.Document});

            _writer.WriteStartDocument();
        }
        
        public void WriteStartElement(string name)
        {
            _writer.WriteStartElement(name);
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
            if (!_isDisposed)
            {
                if (disposing)
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
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
