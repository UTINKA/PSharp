/*
 * Copyright (C) 2017-2018 Alimşah YILDIRIM <alimsahy@gmail.com>
 *
 * PSharp is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * PSharp is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using PSharp.Exceptions;

namespace PSharp.Serialization.XML
{
    public class XmlTreeNode
    {
        public String m_nodeName;
        public String m_value;

        public Boolean m_isTextOnly;

        public Dictionary<String, String> m_attributes;
        public List<XmlTreeNode> m_childNodes;
        public XmlTreeNode m_parentNode;

        public XmlTreeNode(String nodeName, XmlTreeNode parentNode)
        {
            m_nodeName = nodeName;
            m_parentNode = parentNode;
            m_childNodes = new List<XmlTreeNode>();
            m_attributes = new Dictionary<String, String>();
            m_isTextOnly = false;
            m_value = null;
        }

        public XmlTreeNode(XmlReader reader, XmlTreeNode parentNode)
        {
            XmlTreeNode tempNode;

            m_nodeName = reader.Name;
            m_parentNode = parentNode;

            if (reader.NodeType == XmlNodeType.Text)
            {
                m_isTextOnly = true;
                m_value = reader.Value;
            }
            else
            {
                m_isTextOnly = false;
                m_childNodes = new List<XmlTreeNode>();
                m_attributes = new Dictionary<String, String>();

                if (reader.HasAttributes)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        m_attributes.Add(reader.Name, reader.Value);
                    }
                }
                reader.MoveToElement();

                if (!reader.IsEmptyElement)
                {
                    if (reader.HasValue)
                    {
                        reader.Read();
                        m_value = reader.Value;
                    }
                    reader.Read();

                    if (reader != null)
                    {
                        while (!(reader.NodeType == XmlNodeType.EndElement) && (reader.Name == m_nodeName))
                        {
                            tempNode = new XmlTreeNode(reader, this);
                            if (tempNode.m_isTextOnly)
                            {
                                m_value = tempNode.m_value;
                            }
                            else
                            {
                                m_childNodes.Add(tempNode);
                            }
                            reader.Read();
                        }
                    }
                }
            }
        }

        public void AddParameter(String parameterName, String parameterValue)
        {
            if (!m_attributes.ContainsKey(parameterName))
            {
                m_attributes.Add(parameterName, parameterValue);
            }
            else
            {
                throw new XmlTreeNodeParameterAlreadyExistsException();
            }
        }

        public XmlTreeNode AddChild(String nodeName)
        {
            XmlTreeNode newNode = new XmlTreeNode(nodeName, this);
            m_childNodes.Add(newNode);
            return (newNode);
        }

        public void AddChild(XmlTreeNode node)
        {
            m_childNodes.Add(node);
            node.m_parentNode = this;
        }

        public Boolean IsRoot()
        {
            if (m_parentNode == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean HasChild()
        {
            if (m_childNodes.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean HasChild(String nodeName)
        {
            if (m_childNodes.Count > 0)
            {
                Boolean result = false;
                
                foreach (XmlTreeNode node in m_childNodes)
                {
                    if (node.m_nodeName == nodeName)
                    {
                        return true;
                    }
                }
                return result;
            }
            else
            {
                return false;
            }
        }

        public List<XmlTreeNode> GetTheseChildren(String name)
        {
            List<XmlTreeNode> selectedChildren = new List<XmlTreeNode>();
            foreach (XmlTreeNode node in m_childNodes)
            {
                if (node.m_nodeName == name)
                {
                    selectedChildren.Add(node);
                }
            }
            return selectedChildren;
        }

        public XmlTreeNode GetFirstChild(String nodeName)
        {
            foreach (XmlTreeNode node in m_childNodes)
            {
                if (node.m_nodeName == nodeName)
                {
                    return node;
                }
            }
            return null;
        }

        public void WriteNodeXml(XmlWriter writer)
        {
            writer.WriteStartElement(m_nodeName);
            foreach (KeyValuePair<String, String> attributes in m_attributes)
            {
                writer.WriteStartAttribute(attributes.Key);
                writer.WriteValue(attributes.Value);
                writer.WriteEndAttribute();

            }

            if (m_value != null)
            {
                writer.WriteValue(m_value + "\n");
            }

            foreach (XmlTreeNode node in m_childNodes)
            {
                node.WriteNodeXml(writer);
            }
            writer.WriteEndElement();
        }
    }
}
