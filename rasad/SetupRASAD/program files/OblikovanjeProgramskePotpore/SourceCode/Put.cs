using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raspored_asistenti_demonstratori
{
    class Put : Form
    {
        public string put;

        public Put()
        {
            put = Application.StartupPath;
        }
    }
}
