---
title: Assembly References
permalink: /assemblies/
layout: single
classes: wide
sidebar:
  nav: "sidebar"
---

You also have access to methods to assert an assembly does or does not reference another assembly.
These are typically used to enforce layers within an application, such as for example, asserting the web layer does not reference the data layer.
To assert the references, use the following syntax:

```csharp
assembly.Should().Reference(otherAssembly);
assembly.Should().NotReference(otherAssembly);
```
