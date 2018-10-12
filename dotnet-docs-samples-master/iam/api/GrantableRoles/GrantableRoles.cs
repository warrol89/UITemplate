﻿// Copyright 2018 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Iam.v1;
using Google.Apis.Iam.v1.Data;

namespace GoogleCloudSamples
{
    public class GrantableRoles
    {
        public static void Main(string[] args)
        {
            var credential = GoogleCredential.GetApplicationDefault()
                .CreateScoped(IamService.Scope.CloudPlatform);
            var service = new IamService(new IamService.Initializer
            {
                HttpClientInitializer = credential
            });

            string fullResourceName = args[0];

            // [START iam_view_grantable_roles]
            var request = new QueryGrantableRolesRequest
            {
                FullResourceName = fullResourceName
            };
            var response = service.Roles.QueryGrantableRoles(request).Execute();

            foreach (var role in response.Roles)
            {
                Console.WriteLine("Title: " + role.Title);
                Console.WriteLine("Name: " + role.Name);
                Console.WriteLine("Description: " + role.Description);
                Console.WriteLine();
            }
            // [END iam_view_grantable_roles]
        }
    }
}