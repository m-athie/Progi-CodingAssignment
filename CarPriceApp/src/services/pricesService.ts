import axios, { AxiosResponse } from 'axios';

const baseURL = import.meta.env.VITE_API_BASE_URL || 'https://localhost:44308';

export enum VehicleTypes {
	Luxury = 1,
	Common
}
// Define the input type for the calculation request
export interface PricesRequestDTO {
  basePrice: number;
  vehicleType: VehicleTypes;
}

export interface FeeDTO {
	name: string;
	amount: number;
}

export interface PriceResponseDTO {
	totalPrice: number;
	appliedFees: FeeDTO[];
}

// The function to calculate prices
export const calculatePrice = async (request: PricesRequestDTO)
    : Promise<PriceResponseDTO> => {
  const apiUrl = baseURL + '/api/Prices';
  const response: AxiosResponse<PriceResponseDTO> = await axios.post(apiUrl, request);

  return response.data;
};
