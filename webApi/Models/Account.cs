using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webApi.Models;

[Table("accounts")]
    public class Account
    {
        [Column("AccountId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string? AccountType { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        [JsonIgnore]
        public Owner? Owner { get; set; }
        
    }