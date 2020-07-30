using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Horeca.CrossCutting.Enumerations;
using Horeca.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Horeca.IdentityServer.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [MaxLength(50)]
            [RegularExpression("[a-zA-Z]+")]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
          
            [Required]
            [MaxLength(50)]
            [RegularExpression("[a-zA-Z]+")]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            //[Required]
            //[MaxLength(255)]
            //[EmailAddress]
            //[RegularExpression("^[a-zA-Z0-9]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
            //[Display(Name = "Email Address")]
            //public string EmailAddress { get; set; }

            [Required]
            [Phone]
            [MaxLength(25)]
            [Display(Name = "Mobile Number")]
            public string MobileNumber { get; set; }

            [Required]
            [EnumDataType(typeof(Gender))]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [Display(Name = "Professional")]
            public bool Professional { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Professional = user.Professional
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

			var mobileNumber = await _userManager.GetPhoneNumberAsync(user);
			if (Input.MobileNumber != mobileNumber)
			{
				var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.MobileNumber);
				if (!setPhoneResult.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to set phone number.";
					return RedirectToPage();
				}
			}

			user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.MobileNumber = Input.MobileNumber;
            user.Gender = Input.Gender;
            user.DateOfBirth = Input.DateOfBirth;
            user.Professional = Input.Professional;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
