using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
    
{
    public class FormModel
    {
        // --- Informations personnelles ---

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string Prénom { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un genre.")]
        [RegularExpression("^(Homme|Femme|Autre)$", ErrorMessage = "Veuillez sélectionner un genre valide.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "La ville est obligatoire.")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "L'adresse mail est obligatoire.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)\.([\w]+)$", ErrorMessage = "Format de l'adresse courriel invalide.")]
        public string Email { get; set; }

        // --- Informations sur la formation suivie ---

        [Required(ErrorMessage = "La date de début de formation est obligatoire.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(FormModel), nameof(ValidateDateDebut))]
        public DateTime? DateDebut { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un type de formation.")]
        [RegularExpression("^(Formation Cobol|Formation par objet|Formation à double compétence)$", ErrorMessage = "Veuillez sélectionner une formation valide.")]
        public string TypeFormation { get; set; }

        // --- Notice / Avis de formation ---

        [Required(ErrorMessage = "Donnez un avis sur la formation.")]
        public string AvisCobol { get; set; }
        [Required(ErrorMessage = "Donnez un avis sur la formation.")]
        public string AvisCSharp { get; set; }

        // Validation personnalisée pour la date
        public static ValidationResult ValidateDateDebut(DateTime? date, ValidationContext context)
        {
            if (date.HasValue && date.Value >= new DateTime(2021, 1, 1))
            {
                return new ValidationResult("La date doit être inférieure au 01/01/2021.");
            }
            return ValidationResult.Success;
        }
    }
}