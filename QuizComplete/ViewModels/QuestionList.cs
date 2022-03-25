using System.ComponentModel.DataAnnotations;

namespace QuizComplete.ViewModels
{
    public class QuestionList
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Explanation { get; set; }

        public List<Question> questions { get; set; }

    }
}
