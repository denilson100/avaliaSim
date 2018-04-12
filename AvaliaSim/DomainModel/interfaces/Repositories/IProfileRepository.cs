﻿using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.interfaces.Repositories
{
    public interface IProfileRepository
    {
        void Add(Profile profile);
        IEnumerable<Profile> GetAll();
    }
}
