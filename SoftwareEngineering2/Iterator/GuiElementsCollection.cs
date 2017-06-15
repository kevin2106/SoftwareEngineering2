using SoftwareEngineering2.InterfaceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering2.Iterator
{
    class GuiElementCollection : IGuiElementCollection
    {

        public List<IGuiElement> GuiElements { get; set; }

        public GuiElementCollection(List<IGuiElement> guiElements)
        {
            GuiElements = guiElements;
        }

        public void AddGuiElement(IGuiElement guiElement)
        {
            GuiElements.Add(guiElement);
        }

        public void RemoveGuiElement(IGuiElement guiElement)
        {
            GuiElements.Remove(guiElement);
        }

        public IIterator Iterator()
        {
            return new GuiElementIterator(GuiElements);
        }
    }
}
