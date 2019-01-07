﻿using FinalProject.Models;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class EmailSender
    {
        private IFluentEmail _email;

        public EmailSender([FromServices]IFluentEmail email)
        {
            _email = email;
        }

        public void sendProposalEmail(Proposal proposal)
        {
            Trace.WriteLine($"In sendProposalEmail method with {proposal}");

            var email = _email
                .SetFrom(proposal.Designer.Email)
                .To(proposal.Customer.Email)
                .Subject($"Floral Design Proposal for {proposal.Title} 💐")
            //.Body($"Hi {proposal.Customer.Name}!");
                .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/Views/Proposals/ProposalEmail.cshtml", proposal);

            //        .UsingTemplateFromEmbedded("FinalProject.Controllers.ProposalEmail.cshtml",
            //proposal,
            //Assembly.Load("FinalProject.Views"));

            Trace.WriteLine(email);
            Trace.WriteLine(proposal.Designer.Email);
            Trace.WriteLine(proposal.Customer.Email);
            Trace.WriteLine($"{Directory.GetCurrentDirectory()}/Views/Proposals/ProposalEmail.cshtml");

            email.Send();
        }
    }
}
