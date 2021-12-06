using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Interfaces_and_generics_CSharp
{
    interface IStorable
    {
        void Save();
        void Load();
        bool NeedsSave { get; set; }

        void SomeMethod();
    }

    interface IEncryptable
    {
        void Encrypt();
        void Decrypt();

        void SomeMethod();
    }

    class Document : IStorable, IEncryptable, INotifyPropertyChanged
    {
        private string name;
        private Boolean mNeedsSave = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public Document(string s)
        {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public string DocName
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropChanged("DocName");
            }
        }
        public Boolean NeedsSave
        {
            get { return mNeedsSave; }
            set
            {
                mNeedsSave = value;
                NotifyPropChanged("NeedsSave");
            }
        }

        public void Save()
        {
            Console.WriteLine("Saving the document");
        }

        public void Load()
        {
            Console.WriteLine("Loading the document");
        }


        void IStorable.SomeMethod()
        {
            Console.WriteLine("This is the IStorable SomeMethod");
        }
        void IEncryptable.SomeMethod()
        {
            Console.WriteLine("This is the IEncryptable SomeMethod");
        }

        public void SomeMethod()
        {
            Console.WriteLine("This is the class SomeMethod");
        }

        public void Encrypt()
        {
            Console.WriteLine("Encrypting the document");
        }

        public void Decrypt()
        {
            Console.WriteLine("Encrypting the document");
        }


        private void NotifyPropChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Document d = new Document("Test Document");

            /**************************************************
            *   CASTING OPERATORS 'is' and 'as'
            ***************************************************/
            if (d is IStorable)
            {
                d.Save();
            }

            IStorable istore = d as IStorable;

            if (istore != null)
            {
                istore.Load();
            }

            d.SomeMethod();

            IStorable i1 = d as IStorable;
            i1.SomeMethod();

            IEncryptable i2 = d as IEncryptable;
            i2.SomeMethod();

            // Implement a delegate to handle the PropertyChanged event
            d.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) {
                Console.WriteLine("Document property changed: {0}", e.PropertyName);
            };

            d.DocName = "My Document";
            d.NeedsSave = true;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}