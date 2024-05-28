Examen Coopeuch

A partir de la creación de un registro de requerimiento en CRM, se necesita automatizar la creación
de un registro de petición relacionado al requerimiento, la petición debe ser asignada al ejecutivo
resolutor del requerimiento, la descripción del requerimiento debe heredarse en la petición y se
debe asignar una fecha de vencimiento a la petición, la cual que será 10 días después de la creación
del registro. Los campos a considerar para la solución son los siguientes:

Entidad Requerimiento (incident) Tipo Campo
Incidentid GUID
Owner Owner
Description String
New_ejecutivoresolutor Lookup (systemuser)
ticketnumber String
title String

Entidad Petición (new_peticion) Tipo Campo
Regarding LookUp
Owner Owner
Subject String
New_descripcion String
New_name String
New_feharesolucion Datetime

Se necesita generar un plugin para CRM en lenguaje C#, que cumpla el requerimiento descrito
anteriormente.
Consideraciones:
• Generar todo el código de la solución en un solo archivo de clase.
• Omitir la conexión a CRM.

Entregar:
• Código fuente en repositorio GitHub.
