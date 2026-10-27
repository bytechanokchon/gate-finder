export interface SearchGateRequestDto {
    productId: string;
    productAddress: string;
}

export interface SearchGateResponseDto {
    productId: string;
    productAddress: string;
    gate: string;
}