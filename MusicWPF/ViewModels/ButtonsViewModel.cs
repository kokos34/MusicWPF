using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicWPF
{
    /// <summary>
    /// VM for hadling Buttons events
    /// </summary>
    public class ButtonsViewModel : BaseViewModel
    {
        public void RefreshClicked()
        {
            MusicStructureHelper.InitializeDB();
        }
        
    }
}
