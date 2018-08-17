﻿/*
 * Copyright 2015 Google Inc
 *
 * Licensed under the Apache License, Version 2.0(the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using Google.Apis.Dfareporting.v3_2;
using Google.Apis.Dfareporting.v3_2.Data;

namespace DfaReporting.Samples {
  /// <summary>
  /// This example creates an advertiser in a given DCM account. To get
  /// advertisers, see GetAdvertisers.cs.
  /// </summary>
  class CreateAdvertiser : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This example creates an advertiser in a given DCM account. To" +
            " get advertisers, see GetAdvertisers.cs.\n";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new CreateAdvertiser();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(DfaReportingFactory.getInstance());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="service">An initialized Dfa Reporting service object
    /// </param>
    public override void Run(DfareportingService service) {
      long profileId = long.Parse(_T("INSERT_USER_PROFILE_ID_HERE"));

      String advertiserName = _T("INSERT_ADVERTISER_NAME_HERE");

      // Create the advertiser structure.
      Advertiser advertiser = new Advertiser();
      advertiser.Name = advertiserName;
      advertiser.Status = "APPROVED";

      // Create the advertiser.
      Advertiser result = service.Advertisers.Insert(advertiser, profileId).Execute();

      // Display the advertiser ID.
      Console.WriteLine("Advertiser with ID {0} was created.", result.Id);
    }
  }
}
