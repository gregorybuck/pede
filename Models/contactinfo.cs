using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatriciaEdgarAndDonEdgar.Models
{
    public class contactinfo
    {
        [Required(ErrorMessage="Name required, please enter your name")]
        public string contactName { get; set; }
        [Required(ErrorMessage = "Email address required, please enter your email address")]
        public string Email { get; set; }
        public string EmailVerify { get; set; }
        [Required(ErrorMessage = "Please enter a subject")]
        public string subject { get; set; }
        [Required(ErrorMessage = "Please enter a message")]
        public string message { get; set; }
        public string sendstatusmessage { get; set; }
        public string sendstatus { get; set; }
    }
}