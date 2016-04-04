using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

class lucruXML2
{
    public string selectareModul(string cale, String directorSursaO) {
        string numeModul = "";

        //metoda 3
        creereDirectoare cd = new creereDirectoare();
        string directorSursa = directorSursaO+ @"\Syllabus_3\";
        string directorCandidat = "";
        string directorLocatie="";
        string directorModulDest = "";
        string directorModul = "";
        string numeTest = "Test ";
        string numeC = "";
        string prenumeC = "";
        string numeCand = "";
        string modul1 ="";
        string modul2 = "";
        string modul3 = "";
        string modul4 = "";
        string modul5 = "";
        string modul6 = "";
        string modul7 = "";
        XmlTextReader cititor = null; 
        StringBuilder stXml = new StringBuilder();
        int poz = cale.LastIndexOf(@"\") + 1;
        directorLocatie = cale.Substring(0, poz);
        try
        {
                cititor = new XmlTextReader(cale);
                object nume = cititor.NameTable.Add("nume");
                object prenume = cititor.NameTable.Add("prenume");
                object Modul1 = cititor.NameTable.Add("m1");
                object Modul2 = cititor.NameTable.Add("m2");
                object Modul3 = cititor.NameTable.Add("m3");
                object Modul4 = cititor.NameTable.Add("m4");
                object Modul5 = cititor.NameTable.Add("m5");
                object Modul6 = cititor.NameTable.Add("m6");
                object Modul7 = cititor.NameTable.Add("m7");
                while (cititor.Read())
                {
                    if (cititor.NodeType == XmlNodeType.Element)
                    {
                        if(cititor.Name.Equals(nume))
                        {
                            numeC = cititor.ReadString();
                            numeCand = numeC;
                        }
                        if(cititor.Name.Equals(prenume)) {
                            prenumeC = cititor.ReadString();
                            numeCand += " " + prenumeC;
                            numeModul += numeCand + "\t";
                            directorCandidat = directorLocatie + numeCand + @"\";
                            numeModul += directorCandidat + "\r\n";
                            cd.creeereDirector(directorCandidat);
                        }
                        if(cititor.Name.Equals(Modul1) != false)
                        {
                            modul1 = "1." + cititor.ReadString();
                            numeModul +=modul1 + "\r\n";
                        }
                        if (cititor.Name.Equals(Modul2) != false)
                        {
                             modul2 = "2." + cititor.ReadString();
                            directorModul = directorSursa + @"M2\" + numeTest + modul2;
                            directorModulDest = directorCandidat + numeTest + modul2;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul +=directorModulDest + "\r\n";
                        }
                        if(cititor.Name.Equals(Modul3) != false)
                        {
                            modul3 = "3." + cititor.ReadString() +@"\";
                            directorModul = directorSursa + @"M3\" + numeTest + modul3;
                            directorModulDest = directorCandidat + numeTest + modul3;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul += directorModulDest + "\r\n";
                        }
                        if(cititor.Name.Equals(Modul4) != false)
                        {
                            modul4 = "4." + cititor.ReadString() + @"\";
                            directorModul = directorSursa + @"M4\" + numeTest + modul4;
                            directorModulDest = directorCandidat + numeTest + modul4;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul +=directorModulDest +"\r\n";
                        }
                        if(cititor.Name.Equals(Modul5) != false)
                        {
                             modul5 = "5." + cititor.ReadString();
                            directorModul = directorSursa + "M5\\" + numeTest + modul5;
                            directorModulDest = directorCandidat + numeTest + modul5;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul += directorModulDest + "\r\n";
                       }
                        if(cititor.Name.Equals(Modul6) != false)
                        {
                            modul6 = "6." + cititor.ReadString();
                            directorModul = directorSursa + @"M6\" + numeTest + modul6;
                            directorModulDest = directorCandidat + numeTest + modul6;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul += directorModulDest + "\r\n";
                        }
                       if(cititor.Name.Equals(Modul7) != false)
                       {
                            modul7 = "7." + cititor.ReadString();
                            directorModul = directorSursa + @"M7\" + numeTest + modul7;
                            directorModulDest = directorCandidat + numeTest + modul7;
                            cd.copiereDirectoare2(directorModul, directorModulDest);
                            numeModul += directorModulDest + "\r\n";
                        }
                       }
                    cititor.MoveToElement(); 
                }
            }
            catch (Exception e) { numeModul = e.Message; }
        return numeModul;
    }
    public string selectareNume(String cale)
    {
           String directorSursa = "";
        string caleDirector = "";
        string afisareDirCreate="";
        int poz = cale.LastIndexOf(@"\") + 1;
        directorSursa = cale.Substring(0, poz);
        XElement candidati = XElement.Load(cale);
        creereDirectoare cd = new creereDirectoare();
         foreach (XElement nume in candidati.Elements("Student").Elements("Nume"))
        {
            caleDirector = "";
            String n = nume.Value.ToString();
            n = n.Trim();
            caleDirector = directorSursa + n;
            cd.creeereDirector(caleDirector);
            afisareDirCreate += caleDirector + "\r\n";
        }
        return afisareDirCreate;
    }
}
