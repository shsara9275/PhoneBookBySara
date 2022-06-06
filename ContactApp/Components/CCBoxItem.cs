using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Components
{
    public class CCBoxItem {
        private int val;
        public int Value {
            get { return val; }
            set { val = value; }
        }
        
        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string ischecked;

        public string IsChecked
        {
            get { return ischecked; }
            set { ischecked = value; }
        }


        public CCBoxItem() {
        }

        public CCBoxItem(string name, int val) {
            this.name = name;
            this.val = val;
        }

        public CCBoxItem(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

        public override string ToString() {
            return string.Format("name: '{0}', value: {1}, id:{2}, isChecked:{3}", name, val, id, ischecked);
        }
    }
}
