﻿// Copyright (c) 2018 Google LLC.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License. You may obtain a copy of
// the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under
// the License.

using System;
using Xunit;

namespace GoogleCloudSamples
{
    public class IAPClientTest
    {
        readonly CommandLineRunner _iapclient = new CommandLineRunner()
        {
            VoidMain = IAPClientMain.Main,
            Command = "dotnet run"
        };

        [Fact]
        public void TestRun()
        {
            var output = _iapclient.Run("-c",
                Environment.GetEnvironmentVariable("TEST_IAP_CLIENT_ID"),
                "-u", Environment.GetEnvironmentVariable("TEST_IAP_URI"));
            Assert.Equal(0, output.ExitCode);
        }
    }
}
