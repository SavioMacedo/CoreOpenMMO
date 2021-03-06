﻿// <copyright file="IOnlinePlayer.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace COMMO.Data.Contracts
{
    public interface IOnlinePlayer
    {
        string Name { get; set; }

        int Level { get; set; }

        string Vocation { get; set; }
    }
}
