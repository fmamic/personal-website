using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfPpijProgrami
{
    public class ListBoxPoly
    {
        public virtual void AddListElements(List<string> nameList, Podaci podaci)
        {
        }
    }

    public class ListBoxTwitter : ListBoxPoly
    {
        public override void AddListElements(List<string> nameList, Podaci podaci)
        {
            try
            {
                foreach (var friend in podaci.TwitterFriends)
                {
                    nameList.Add(friend.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ListBoxPoly " + e);
            }
        }
    }

    public class ListBoxFacebook : ListBoxPoly
    {
        public override void AddListElements(List<string> nameList, Podaci podaci)
        {
            try
            {
                foreach (var friend in podaci.FacebookFriends)
                {
                    nameList.Add(friend.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ListBoxPoly " + e);
            }
        }
    }

    public class ListBoxPpijBoard : ListBoxPoly
    {
        public override void AddListElements(List<string> nameList, Podaci podaci)
        {
            try
            {
                foreach (var friend in podaci.PpijFriends)
                {
                    nameList.Add(friend.Name);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ListBoxPoly " + e);
            }
        }
    }

    public class AddElements
    {

        public static void addElementsListBox(List<string> nameList, System.Windows.Controls.ListBox listBox)
        {
            nameList.Sort();

            foreach (var item in nameList)
            {
                listBox.Items.Add(item);
            }
        }
    }
}
