namespace Charities
open System.Collections

module Types =

    type NgoInfo = { name: string
                     datecalled: int
                     faithbased: bool } 

    
    type NgoCategory = 
        | VictimRescue of NgoInfo
        | Safehouse of NgoInfo
        | Aftercare of NgoInfo
        | PovertyRelief of NgoInfo
        | HomelessShelter of NgoInfo
        | DomesticViolenceShelter of NgoInfo

    type Caller =
        | Victim
        | Survivor
        | Advocate

//Aftercare for sex trafficking victims includes but is not limited to educational support, skills training,
//medical and dental care, economic development/income support, safehouse, transitional housing, and
//family reunification (where possible), legal help with prostitution charges, and community reintegration support 
    type RequestedHelp =
        | VictimRescue
        | Aftercare 
        | EmergencyResponse

    type UnmetNeeds =
        | Medical 
        | Dental
        | Legal
        | Safebed
        | LongTermHousing
        | EconomicSupport
        | SkillsTraining
        | EducationalHelp
        | Reintegration
        | FamilyReunification

    type Ngo = Ngo of NgoInfo * NgoCategory * string


    type Followup =
        | NoFollowup //No caseworker or agency staff following up to ensure victim/survivor got helped
        | Followedup of Help
        | SelfReferred of Help

    and Help =
        | Helped // Got helped with everything needed
        | ExhaustedAllOptions of Followup // Exhausted options and still not helped or only partially helped
        | DeniedHelp of Followup
        | WrongHelp of Followup
        | Referred of RefToNextNgo

    and RefToNextNgo = RefToNextNgo of Followup * Ngo

    type PoliceDispatch =
        | VictimRescued //Victim extricated from trafficking situation and not arrested for prostitution or illegal immigration
        | CopsNoHelp of Followup // Cops no-show, or cops show up but arrest victim for prostitution

    type CallOutcome =
        | ProvidedHelp // The victim/survivor got helped with all their unmet needs
        | EmergencyResponse of PoliceDispatch 
        | Referral of RefToNextNgo
        | CallDisconnect of Followup
        | HelpFail of Followup


    type CallRequest =
        | JobApplication //Survivor called an anti-trafficking NGO to apply for a job instead of charitable aid

    