# This code parses date/times, so please
#
#     pip install python-dateutil
#
# To use this code, make sure you
#
#     import json
#
# and then, to convert JSON from a string, do
#
#     result = person_from_dict(json.loads(json_string))

from dataclasses import dataclass
from uuid import UUID
from datetime import datetime
from typing import Any, List, TypeVar, Callable, Type, cast
import dateutil.parser


T = TypeVar("T")


def from_str(x: Any) -> str:
    assert isinstance(x, str)
    return x


def from_int(x: Any) -> int:
    assert isinstance(x, int) and not isinstance(x, bool)
    return x


def from_datetime(x: Any) -> datetime:
    return dateutil.parser.parse(x)


def from_list(f: Callable[[Any], T], x: Any) -> List[T]:
    assert isinstance(x, list)
    return [f(y) for y in x]


def to_class(c: Type[T], x: Any) -> dict:
    assert isinstance(x, c)
    return cast(Any, x).to_dict()


@dataclass
class PersonElement:
    orcid: str
    localid: str
    deic_project_id: str
    hpc_center_id: UUID
    sub_hpc_center_id: UUID
    university_id: int
    id_expanded: str
    access_type: int
    access_start_date: datetime
    access_end_date: datetime
    cpu_core_time_assigned: int
    cpu_core_time_used: int
    gpu_core_time_assigned: int
    gpu_core_time_used: int
    storage_assigned_in_mb: int
    storage_used_in_mb: int
    node_time_assigned: int
    node_time_used: int

    @staticmethod
    def from_dict(obj: Any) -> 'PersonElement':
        assert isinstance(obj, dict)
        orcid = from_str(obj.get("orcid"))
        localid = from_str(obj.get("localid"))
        deic_project_id = from_str(obj.get("deicProjectId"))
        hpc_center_id = UUID(obj.get("hpcCenterId"))
        sub_hpc_center_id = UUID(obj.get("subHPCCenterId"))
        university_id = from_int(obj.get("universityId"))
        id_expanded = from_str(obj.get("idExpanded"))
        access_type = from_int(obj.get("accessType"))
        access_start_date = from_datetime(obj.get("accessStartDate"))
        access_end_date = from_datetime(obj.get("accessEndDate"))
        cpu_core_time_assigned = from_int(obj.get("cpuCoreTimeAssigned"))
        cpu_core_time_used = from_int(obj.get("cpuCoreTimeUsed"))
        gpu_core_time_assigned = from_int(obj.get("gpuCoreTimeAssigned"))
        gpu_core_time_used = from_int(obj.get("gpuCoreTimeUsed"))
        storage_assigned_in_mb = from_int(obj.get("storageAssignedInMB"))
        storage_used_in_mb = from_int(obj.get("storageUsedInMB"))
        node_time_assigned = from_int(obj.get("nodeTimeAssigned"))
        node_time_used = from_int(obj.get("nodeTimeUsed"))
        return PersonElement(orcid, localid, deic_project_id, hpc_center_id, sub_hpc_center_id, university_id, id_expanded, access_type, access_start_date, access_end_date, cpu_core_time_assigned, cpu_core_time_used, gpu_core_time_assigned, gpu_core_time_used, storage_assigned_in_mb, storage_used_in_mb, node_time_assigned, node_time_used)

    def to_dict(self) -> dict:
        result: dict = {}
        result["orcid"] = from_str(self.orcid)
        result["localid"] = from_str(self.localid)
        result["deicProjectId"] = from_str(self.deic_project_id)
        result["hpcCenterId"] = str(self.hpc_center_id)
        result["subHPCCenterId"] = str(self.sub_hpc_center_id)
        result["universityId"] = from_int(self.university_id)
        result["idExpanded"] = from_str(self.id_expanded)
        result["accessType"] = from_int(self.access_type)
        result["accessStartDate"] = self.access_start_date.isoformat()
        result["accessEndDate"] = self.access_end_date.isoformat()
        result["cpuCoreTimeAssigned"] = from_int(self.cpu_core_time_assigned)
        result["cpuCoreTimeUsed"] = from_int(self.cpu_core_time_used)
        result["gpuCoreTimeAssigned"] = from_int(self.gpu_core_time_assigned)
        result["gpuCoreTimeUsed"] = from_int(self.gpu_core_time_used)
        result["storageAssignedInMB"] = from_int(self.storage_assigned_in_mb)
        result["storageUsedInMB"] = from_int(self.storage_used_in_mb)
        result["nodeTimeAssigned"] = from_int(self.node_time_assigned)
        result["nodeTimeUsed"] = from_int(self.node_time_used)
        return result


def person_from_dict(s: Any) -> List[PersonElement]:
    return from_list(PersonElement.from_dict, s)


def person_to_dict(x: List[PersonElement]) -> Any:
    return from_list(lambda x: to_class(PersonElement, x), x)
