using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace TPLOCAL1
{
    public class ListReview
    {
        public List<Avis> GetAvis(string file)
        {
            List<Avis> ListReviews = new List<Avis>();
            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(file))
            {
                using (StreamReader streamDoc = new StreamReader(file))
                {
                    string dataXml = streamDoc.ReadToEnd();
                    xmlDoc.LoadXml(dataXml);
                }
                // récupération des noueds
                foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
                {
                    string name = node["Nom"].InnerText;
                    string prenom = node["Prénom"].InnerText;
                    string avisdonne = node["Avis"].InnerText;

                    // Creation de l'objet de notification à ajouter à la liste des résultats
                    Avis avis = new Avis
                    {
                        Name = name,
                        Prenom = prenom,
                        Avisdonne = avisdonne
                    };
                    ListReviews.Add(avis);
                }
            }
            return ListReviews;
        }
    }

    public class Avis
    {
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Avisdonne { get; set; }
    }
}