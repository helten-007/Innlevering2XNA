using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innlevering2
{
    public interface IDrawMenu
    {
        void AddButton(MenuData button);
        void RemoveButton(MenuData button);
    }
}
