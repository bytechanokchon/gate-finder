import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseResponse } from "../dtos/baseResponse.dto";
import { ExtractDataResponseDto } from "../dtos/ocr.dto";

@Injectable({
  providedIn: 'root'
})
export class OcrService {
    private readonly apiUrl = 'https://localhost:7295/api/Ocr';

    constructor(private http: HttpClient) {}

    extract(images: FormData) {
        return this.http.post<BaseResponse<ExtractDataResponseDto[][]>>(`${this.apiUrl}/Extract`, images);
    }
}