import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SearchGateRequestDto, SearchGateResponseDto } from "../dtos/gate.dto";
import { BaseResponse } from "../dtos/baseResponse.dto";

@Injectable({
    providedIn: 'root'
})
export class GateService {
    private readonly apiUrl = 'https://localhost:7295/api/Gate';

    constructor(private http: HttpClient) {}

    search(req: SearchGateRequestDto[]) {
        return this.http.post<BaseResponse<SearchGateResponseDto[]>>(`${this.apiUrl}/Search`, req)
    }
}