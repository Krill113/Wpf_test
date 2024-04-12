using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Wpf_test
{
    public class myclass
    {
        public class NetworkProps : INotifyPropertyChanged
        {

            private string netName;
            public string NetName
            {
                get
                {
                    return netName;
                }
                set
                {
                    netName = value;
                }
            }

            private string netDesc;
            public string NetDesc
            {
                get
                {
                    return netDesc;
                }
                set
                {
                    if (netDesc == value) return;
                    netDesc = value;
                    OnPropertyChanged("NetDesc");
                }
            }

            private string netType;
            public string NetType
            {
                get
                {
                    return netType;
                }
                set
                {
                    if (netType == value) return;
                    netType = value;
                    OnPropertyChanged("NetType");
                }
            }


            private PropFromDict propFromDict;
            public PropFromDict PropFromDict
            {
                get
                {
                    return propFromDict;
                }
                set
                {
                    if (propFromDict == value) return;
                    propFromDict = value;
                    OnPropertyChanged("PropFromDict");
                }
            }

            public NetworkProps() { }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        public class PropFromDict : INotifyPropertyChanged
        {
            public string PropName { get; set; }

            private string selectedVal;
            public string SelectedVal
            {
                get { return selectedVal; }
                set
                {
                    if (selectedVal == value) return;
                    selectedVal = value;
                    OnPropertyChanged("SelectedVal");
                }
            }

            public Dictionary<string, int> StrIdDicr { get; set; }
            public int SelectedID => StrIdDicr[selectedVal];
            public PropFromDict(string propName) { PropName = propName; }


            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

    }
}
