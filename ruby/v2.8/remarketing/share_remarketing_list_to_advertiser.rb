#!/usr/bin/env ruby
# Encoding: utf-8
#
# Copyright:: Copyright 2017, Google Inc. All Rights Reserved.
#
# License:: Licensed under the Apache License, Version 2.0 (the "License");
#           you may not use this file except in compliance with the License.
#           You may obtain a copy of the License at
#
#           http://www.apache.org/licenses/LICENSE-2.0
#
#           Unless required by applicable law or agreed to in writing, software
#           distributed under the License is distributed on an "AS IS" BASIS,
#           WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
#           implied.
#           See the License for the specific language governing permissions and
#           limitations under the License.
#
# This example shares an existing remarketing list with the specified
# advertiser.

require_relative '../dfareporting_utils'

def share_remarketing_list_to_advertiser(profile_id, advertiser_id,
    remarketing_list_id)
  # Authenticate and initialize API service.
  service = DfareportingUtils.get_service()

  # Load the existing share info.
  share = service.get_remarketing_list_share(profile_id, remarketing_list_id)
  share.shared_advertiser_ids ||= []

  if share.shared_advertiser_ids.include?(advertiser_id)
    puts 'Remarketing list %d is already shared to advertiser %d.' %
        [remarketing_list_id, advertiser_id]
  else
    share.shared_advertiser_ids <<= advertiser_id

    # Update the share info with the newly added advertiser ID.
    share = service.update_remarketing_list_share(profile_id, share)

    puts 'Remarketing list %d is now shared to advertiser ID(s): %s' %
        [remarketing_list_id, share.shared_advertiser_ids.join(", ")]
  end
end

if __FILE__ == $0
  # Retrieve command line arguments.
  args = DfareportingUtils.get_arguments(ARGV, :profile_id, :advertiser_id,
      :remarketing_list_id)

  share_remarketing_list_to_advertiser(args[:profile_id], args[:advertiser_id],
      args[:remarketing_list_id])
end
