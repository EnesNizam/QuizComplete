using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizComplete.ViewModels
{
    public class Question
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? QuestionPost { get; set; }

        [Required]
        public string? OptionA { get; set; }

        [Required]
        public string? OptionB { get; set; }

        [Required]
        public string? OptionC { get; set; }
        [Required]
        public string? OptionD { get; set; }

        [Required]
        public string? CorrectOption { get; set; }

        [ForeignKey("QuestionList")]
        public int? QuestionListID { get; set; }

        [ForeignKey(nameof(QuestionListID))]
        public QuestionList? Questionlist { get; set; }
    }
}
