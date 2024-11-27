<template>
    <div class="price-calculator">
      <h1>Car Price Calculator</h1>
      
      <!-- Input for Vehicle Base Price -->
      <div>
        <label for="base-price">Vehicle Base Price:</label>
        <input
          type="number"
          id="base-price"
          v-model.number="basePrice"
          placeholder="Enter base price"
        />
				<div v-if="errorMessage" class="error-message">{{ errorMessage }}</div>
      </div>
  
      <!-- Dropdown for Vehicle Type -->
      <div>
        <label for="vehicle-type">Vehicle Type:</label>
        <select id="vehicle-type" v-model="vehicleType">
            <option :value="vehicleTypes.Luxury">Luxury</option>
            <option :value="vehicleTypes.Common">Common</option>
        </select>
      </div>
			<div>
      	<button @click="calculateTotal">Calculate Price</button>
    	</div>
      <!-- Fees List -->
      <div v-if="appliedFees.length">
        <h2>Fees</h2>
        <ul>
          <li v-for="appliedFee in appliedFees" :key="appliedFee">
            {{ appliedFee.name }}: ${{ appliedFee.amount.toFixed(2) }}
          </li>
        </ul>
      </div>
  
      <!-- Total Cost -->
      <div v-if="totalPrice !== null">
        <h2>Total Price: ${{ totalPrice.toFixed(2) }}</h2>
      </div>
    </div>
  </template>
  
<script setup lang="ts">
  import { ref, onMounted } from "vue";
  import axios from "axios";
  import { calculatePrice, PricesRequestDTO, 
		FeeDTO, PriceResponseDTO, VehicleTypes
   } from '../services/pricesService';
  
  // Reactive state variables
	const basePrice = ref<number>(0);
	const vehicleType = ref<VehicleTypes>(VehicleTypes.Common);
	const appliedFees = ref<FeeDTO[]>([]);
	const totalPrice = ref<number | null>(null);
	const vehicleTypes = VehicleTypes;
	const errorMessage = ref<string | null>(null);
  
  // Function to calculate total cost and fetch fees from the API
  const calculateTotal = async () => {
    try {
      if (basePrice.value <= 0) {
				errorMessage.value = "Please enter a valid base price greater than 0.";
				return;
			} else {
				errorMessage.value = null;
			}
      const requestData : PricesRequestDTO = {
        basePrice: basePrice.value,
        vehicleType: vehicleType.value,
      };
      const priceData: PriceResponseDTO = await calculatePrice(requestData);
      totalPrice.value = priceData.totalPrice; 
      appliedFees.value = priceData.appliedFees;
    } catch (error) {
      console.error("Error calculating total cost:", error);
      fees.value = [];
      totalCost.value = null;
    }
  };
  </script>
  
  <style scoped>
  .price-calculator {
    max-width: 500px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ddd;
    border-radius: 8px;
  }

	.error-message {
		color: red;
		font-size: 14px;
	}
  
  h1,
  h2 {
    text-align: center;
  }
  
  label {
    display: block;
    margin: 10px 0 5px;
  }
  
	input,
	select,
	button {
		width: 100%; /* Ensure all form elements take the full available width */
		padding: 8px;
		margin-bottom: 15px;
		border: 1px solid #ccc;
		border-radius: 4px;
		box-sizing: border-box; /* Include padding and border in the total width */
	}
  
  ul {
    list-style: none;
    padding: 0;
  }
  
  li {
    margin: 5px 0;
  }
  </style>
  