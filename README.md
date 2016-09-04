Welcome to NWheels
=======

According to our observations, commonality in the needs of enterprise application projects is significantly higher than variability. We take this as an opportunity to slash project costs and timeframes, improve software quality, and reduce technical risks. 

> Learn more: [Motivation and goals](https://github.com/felix-b/NWheels/wiki/Motivation-and-goals) in Wiki

## What is NWheels

NWheels is an infrastructural ecosystem and ongoing development effort, which is aimed to supply A-to-Z architectural recipes, innovative runtime platform, and high productivity development framework for enterprise applications based on the .NET Core platform.

>**What applications it will be possible to build?** Typical client-server and N-tier micro-services, web sites and services, standalone desktop apps and CLI programs; serverless (FaaS) apps.
>
>**Where will they run?** Server-side will run on Linux, Windows, OS X; client side will run on web browsers, mobile devices, Windows/Linux/OS X desktops, Smart TV and IVR platforms.
>
>**Clouds?** Yes Sir. Any compatible IaaS will be supported. There will be no dependency on any specific vendor PaaS, thus as an example, a business will be able to run on Azure with disaster recovery on AWS and Google Cloud.
>
> **High-end SLA?** 24x7 availability, elastic scalability (on supported vendors), low-latency, high-throughput applications.
>
> Learn more: [Feature highlighs](#feature-highlights) below, [Aspects of NWheels](https://github.com/felix-b/NWheels/wiki/intro-aspects-of-nwheels) in Wiki 

## License

NWheels is available under the **MIT license**, and is aimed to stay **free forever**.

## Current Status 

#### September 2016 - the concept is proven 

NWheels has not yet released its platform for general availability.

The proof-of-concept version named **milestone Afra**, is now stable and serves a basis for two proprietary real-world applications.

> Development of two serious software systems, which we did on top of  NWheels milestone Afra framework, evidenced that it is possible to deliver and maintain a superior working product with less resources by an order of magnitude, compared to competing vendors of similar software.

## Next Step

**Milestone Boda** is now starting with **new greenfield codebase**. 

Why new codebase:
- Target .NET Core (milestone Afra targeted .NET Framework 4.5)
- Fix major deficiencies of milestone Afra:
  - simplify design, implementation, and exposed APIs
  - keep technical debt very low
  - do it TDD way
- Implement improved architecture, based on lessons learned
- Let contributors catch up early

## Call for Contributors

**NWheels makes promise to change the game of enterprise software development - [learn how](https://github.com/felix-b/NWheels/wiki/Motivation-and-goals)**.

> What will it mean to different people? 
>
> - To developers - more accomplishments for much less effort, and it is fun
> - To architects - more ready building blocks and capabilities, more experimentation for less re-work
> - To software vendors - more competitiveness for less resources, time, and budget
> - To entrepreneurs - more innovation for less investment and risk, shorter time to market
> - To businesses - more reliability and availability of critical services for no cloud vendor lock-in  
>    - e.g. run on Azure, recover on Amazon and Google
> - To users - more cool apps and services available

If NWheels holds its promise and reaches its goals, this would mean no less than revolution. It is doable - we did it (milestone Afra), and we want to do it again, this time for real.  

#### Want to get involved? **[Please find instructions and guidelines here](https://github.com/felix-b/NWheels/wiki/community-contributors-guidelines)**.

We believe that code sharing and collaboration, driven by enthusiasm for quality and professionalism, have much better chances of delivering working and (re)usable software, rather than isolated development effort, driven by sales plan of a profit-oriented organization. 

## Feature Highlights

NWheels is aimed to exhibit the following characteristics:

#### A-to-Z response to common demand

  - implemented architectural recipes that cover all application layers and tiers: projects are not left to sweat over gluing multiple 3rd-party building blocks together
  - ready answers to common requirements and concerns, ranging from basic features like authorization, to advanced scenarios like elastic scalability
  - built-in support for DevOps procedures, automation of clouds, and easy integration with application lifecycle management

#### Get significantly more for doing much less. For example:

  - scaffold a new application - and have it automatically built, deployed, and monitored on cloud or on premises environments, where the only piece that is missing, is the unique features you are going to develop.
  - code domain model, logic, and conceptual UI - and get whole layers of your system automatically implemented by conventions - including data persistence, CLI, and UI apps bound to the domain model, in-process or through invocations of REST/backend APIs.
  - use Information Security building block domain - and get user account management, authentication, and common user stories such as  'confirm email' and 'change password', out of the box.
  - define access control rules for different user profiles - and have them transparently enforced through all application layers, including access to both operations and data.
  - define semantic logging messages - and get automatic metric collection, thresholds, circuit breakers, and alerts.

#### Proven architectures, approaches, and patterns, for dramatically less effort on your side. To name a few:

  - hexagonal architecture 
  - micro-services
  - domain-driven design
  - command-line interface over application functions
  - distributed consensus and service discovery
  - containerization

#### Innovative approaches
  - convention over implementation - transparent implementation of abstractions by pipelines of pluggable conventions - an approach, which eliminates majority of repetitive mechanical code from your codebase.
  - layered unobtrusive customization - multiple reusable orthogonal adaptations are stacked on top of white-label version. Plugged into customer-specific configurations, the adaptations extend and alter domain model, logic, and conceptual UI, while the white-label version remains unchanged. 
  - late compilation - model-based components are late-compiled against customized models and concrete technology stacks
  - building block domains - adaptive and reusable models, logic, and conceptual UI parts for common domains, such as e-commerce, CRM, booking, accounting.

#### Platform at your service
  - communication endpoints, backend APIs, messaging, workflows, scheduled jobs, and more
  - elastic on-demand scalability and automatic failover
  - cloud, hybrid, and on-premise deployments
  - no dependency on specific cloud vendor PaaS; run on any compatible IaaS - no vendor lock-in

#### Ready DevOps/ALM toolchain
  - automated deployment to dev boxes and test/prod environments on premise, hybrid, and on cloud
  - runtime health monitoring, metric collection, and tools for production intelligence
  - continuous deployment and continuous integration with optional developer git flow, personal builds, and gated commits
  - product and agile process management
  - all of the above is cross-tracked for maximal visibility and decision support

# Learn More - Resources

- Project Wiki - comprehensive information for both consumers and contributors
- Introduction
- Motivation and goals
- Feature explorer
