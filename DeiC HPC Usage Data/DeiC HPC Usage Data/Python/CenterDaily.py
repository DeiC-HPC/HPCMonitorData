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
#     result = center_daily_from_dict(json.loads(json_string))

from dataclasses import dataclass
from uuid import UUID
from datetime import datetime
from typing import Any, List, TypeVar, Callable, Type, cast
import dateutil.parser


T = TypeVar("T")


def from_datetime(x: Any) -> datetime:
    return dateutil.parser.parse(x)


def from_str(x: Any) -> str:
    assert isinstance(x, str)
    return x


def from_int(x: Any) -> int:
    assert isinstance(x, int) and not isinstance(x, bool)
    return x


def from_list(f: Callable[[Any], T], x: Any) -> List[T]:
    assert isinstance(x, list)
    return [f(y) for y in x]


def to_class(c: Type[T], x: Any) -> dict:
    assert isinstance(x, c)
    return cast(Any, x).to_dict()


@dataclass
class CenterDailyElement:
    hpc_center_id: UUID
    sub_hpc_center_id: UUID
    date: datetime
    orcid: str
    deic_project_id: str
    university_id: int
    id_expanded: str
    access_type: int
    max_cpu_core_time: int
    used_cpu_coretime: int
    max_gpu_core_time: int
    used_gpu_coretime: int
    storage_used_in_gb: int
    network_usage_in_gb: int
    network_avg_usage: int
    max_node_time: int
    used_note_time: int

    @staticmethod
    def from_dict(obj: Any) -> 'CenterDailyElement':
        assert isinstance(obj, dict)
        hpc_center_id = UUID(obj.get("hpcCenterId"))
        sub_hpc_center_id = UUID(obj.get("subHPCCenterId"))
        date = from_datetime(obj.get("date"))
        orcid = from_str(obj.get("orcid"))
        deic_project_id = from_str(obj.get("deicProjectId"))
        university_id = from_int(obj.get("universityId"))
        id_expanded = from_str(obj.get("idExpanded"))
        access_type = from_int(obj.get("accessType"))
        max_cpu_core_time = from_int(obj.get("maxCPUCoreTime"))
        used_cpu_coretime = from_int(obj.get("usedCPUCoretime"))
        max_gpu_core_time = from_int(obj.get("maxGPUCoreTime"))
        used_gpu_coretime = from_int(obj.get("usedGPUCoretime"))
        storage_used_in_gb = from_int(obj.get("storageUsedInGB"))
        network_usage_in_gb = from_int(obj.get("networkUsageInGB"))
        network_avg_usage = from_int(obj.get("networkAvgUsage"))
        max_node_time = from_int(obj.get("maxNodeTime"))
        used_note_time = from_int(obj.get("usedNoteTime"))
        return CenterDailyElement(hpc_center_id, sub_hpc_center_id, date, orcid, deic_project_id, university_id, id_expanded, access_type, max_cpu_core_time, used_cpu_coretime, max_gpu_core_time, used_gpu_coretime, storage_used_in_gb, network_usage_in_gb, network_avg_usage, max_node_time, used_note_time)

    def to_dict(self) -> dict:
        result: dict = {}
        result["hpcCenterId"] = str(self.hpc_center_id)
        result["subHPCCenterId"] = str(self.sub_hpc_center_id)
        result["date"] = self.date.isoformat()
        result["orcid"] = from_str(self.orcid)
        result["deicProjectId"] = from_str(self.deic_project_id)
        result["universityId"] = from_int(self.university_id)
        result["idExpanded"] = from_str(self.id_expanded)
        result["accessType"] = from_int(self.access_type)
        result["maxCPUCoreTime"] = from_int(self.max_cpu_core_time)
        result["usedCPUCoretime"] = from_int(self.used_cpu_coretime)
        result["maxGPUCoreTime"] = from_int(self.max_gpu_core_time)
        result["usedGPUCoretime"] = from_int(self.used_gpu_coretime)
        result["storageUsedInGB"] = from_int(self.storage_used_in_gb)
        result["networkUsageInGB"] = from_int(self.network_usage_in_gb)
        result["networkAvgUsage"] = from_int(self.network_avg_usage)
        result["maxNodeTime"] = from_int(self.max_node_time)
        result["usedNoteTime"] = from_int(self.used_note_time)
        return result


def center_daily_from_dict(s: Any) -> List[CenterDailyElement]:
    return from_list(CenterDailyElement.from_dict, s)


def center_daily_to_dict(x: List[CenterDailyElement]) -> Any:
    return from_list(lambda x: to_class(CenterDailyElement, x), x)
