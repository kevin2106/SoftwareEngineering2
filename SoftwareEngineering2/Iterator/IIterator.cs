﻿using SoftwareEngineering2.InterfaceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering2.Iterator
{
    interface IIterator
    {
        IGuiElement Next();
        bool HasNext();
    }
}
