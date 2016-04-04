using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Permissions;

    class creereDirectoare
    {
        public void copiereFisiere(string destinatar, string expeditor)
        {
            DirectoryInfo dest = new DirectoryInfo(destinatar);
            string[] caleFis = Directory.GetFiles(expeditor);
            foreach (string s in caleFis)
            {
                 FileInfo fisierCopiat = new FileInfo(s);
                try
                {
                    fisierCopiat.CopyTo(Path.Combine(destinatar, Path.GetFileName(s)));
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
              }
        }

        public void setareDreptScriere(string caleDirector) {
            FileIOPermission fiop = new FileIOPermission(PermissionState.None);
            DirectoryInfo dir=new DirectoryInfo(caleDirector);
            
        }
        public void copiereDirectoare(string caleDestinatar, string caleExpeditor)
        {
            DirectoryInfo dirExpeditor = new DirectoryInfo(caleExpeditor);
            DirectoryInfo dirDestinatar = new DirectoryInfo(caleDestinatar);
            this.copiereFisiere(caleDestinatar, caleExpeditor);
            if (dirExpeditor.GetDirectories() != null)
            {
                foreach (DirectoryInfo d in dirExpeditor.GetDirectories())
                {
                    string caleDest2 = caleDestinatar + "\\" + d.Name;
                    string caleExp2 = caleExpeditor + "\\" + d.Name;
                    try
                    {
                        dirDestinatar.CreateSubdirectory(d.Name);
                        this.copiereDirectoare(caleDest2, caleExp2);
                    }
                    catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
                }
            }
        }

        public void creeereDirector(String cale) {
            string afisare="";
            try {
                DirectoryInfo dir =Directory.CreateDirectory(cale);
            }
            catch (Exception e) { afisare = "A intervenit o eroare: " + e.Message; }
        }
        public void copiereDirectoare2(string Src, string Dst)
        {
            String[] Files;
             if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                 if (Directory.Exists(Element))
                    copiereDirectoare2(Element, Dst + Path.GetFileName(Element));
                else
                    File.Copy(Element, Dst + Path.GetFileName(Element));
                    FileInfo fisier = new FileInfo(Dst + Path.GetFileName(Element));
                    fisier.IsReadOnly = false;

            }
        }
   }